﻿using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc;
using static grpcCommonLibrary.RobotService;
using Sensor.cs;
using Grpc.Core.Logging;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace grpcCommonLibrary
{
    [Service]
    public interface IRobotService
    {
        [Operation]
        IAsyncEnumerable<SensorResponse> SensorTest(SensorRequest request, CallContext context = default);
    }

    public class RobotService : IRobotService
    {
        Altimeter alt = new Altimeter();
        async IAsyncEnumerable<SensorResponse> IRobotService.SensorTest(SensorRequest request, CallContext context)
        {
            alt.Connect();
            await foreach (var data in GetDataStream(context))
            {
                if (context.CancellationToken.IsCancellationRequested)
                    yield break;
                var resp = new SensorResponse();
                resp.result = data;
                yield return resp;
            }

            
        }

        private async IAsyncEnumerable<double> GetDataStream(CallContext context)
        {
            var dataChannel = System.Threading.Channels.Channel.CreateUnbounded<double>();

            EventHandler<double> dataHandler = (s, d) =>
            {
                try
                {
                    dataChannel.Writer.WriteAsync(d, context.CancellationToken);
                }
                catch (InvalidOperationException) { }
            };

            try
            {
                alt.DataReceived += dataHandler;


                double data = 0.0f;

                while (!context.CancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        data = await dataChannel.Reader.ReadAsync(context.CancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    if (!context.CancellationToken.IsCancellationRequested)
                        yield return data;
                }
            }
            finally
            {
                alt.DataReceived -= dataHandler;
                (dataChannel as IDisposable)?.Dispose();
            }
        }

    }
}
