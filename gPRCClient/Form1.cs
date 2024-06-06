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
            GetRobotService();
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

                    this.BeginInvoke(new Action(() => {
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
            DisplaySensorData();
        }
    }
}


