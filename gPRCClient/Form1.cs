using ProtoBuf.Grpc.Client;
using Grpc.Core;
using grpcCommonLibrary;
using System.Diagnostics;
using System.Windows.Forms;

namespace gPRCClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private Channel grpcChannel;
        private IRobotService robotService;

        private void Form1_Load(object sender, EventArgs e)
        {
            //if we don't sleep for a while, the robot channel has not been established
            //Thread.Sleep(500);

        }

        private async void GetRobotService()
        {
            grpcChannel = await GrpcHelper.GetRobotChannel();
            robotService = grpcChannel.CreateGrpcService<IRobotService>();
        }

        private async void DisplaySensorData()
        {
            if (grpcChannel != null)
            {
                await foreach (var response in robotService.SensorTest(new SensorRequest() { param = 1 }))
                {

                    this.BeginInvoke(new Action(() =>
                    {
                        listBox.Items.Add(response.result.ToString());
                        if (listBox.Items.Count >= 20)
                        {
                            listBox.Items.RemoveAt(0); // Remove the oldest item
                        }
                    }
                    ));
                    //Debug.WriteLine($"Received: {response.result}");
                }
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            GetRobotService();
            Thread.Sleep(500);

            DisplaySensorData();
        }

        private void button_setServerAddr_Click(object sender, EventArgs e)
        {
            string ip = textBox_serverIP.Text.Trim();
            if (string.IsNullOrEmpty(ip))
                return;
            var address = ip + ":11421";
            GrpcHelper.SetRobotChannel(address);

        }

        private async void  button_trigger_Click(object sender, EventArgs e)
        {
            GetRobotService();
            if (grpcChannel != null)
            {
                var  response = await robotService.ServoTest(new ServoRequest());
                if (response.result)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        label_signal.BackColor = Color.Green;
                    }
                    ));
                }
            }


        }
    }
}


