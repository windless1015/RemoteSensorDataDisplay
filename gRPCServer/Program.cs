using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System.Net;
using Autofac.Extensions.DependencyInjection;
using Grpc.Core;
using Serilog;
using gRPCServer;


namespace gPRCServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        string ip = GetIPAddress();
                        if (ip == "")
                            return;
                        IPAddress ipaddress = IPAddress.Parse(ip);
                        options.Listen(ipaddress, 11421, listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http2;
                        });
                    });

                    webBuilder.UseStartup<Startup>();
                });
        //.UseWindowsService() //temproraily 
        //.UseSystemd();


        private static string GetIPAddress()
        { 
            string hostName = Dns.GetHostName();
            IPHostEntry hostentry = Dns.GetHostEntry(hostName);
            foreach (IPAddress ip in hostentry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && 
                    ip.ToString().StartsWith("192.168.0"))
                    return ip.ToString();
            }
            return "";
        }
    }
}