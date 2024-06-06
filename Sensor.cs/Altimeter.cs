using System.Diagnostics;
using System.Threading.Channels;

namespace Sensor.cs
{
    public class Altimeter
    {
        private YAltitude _altitude;
        private Task _sensorTask;
        private CancellationTokenSource _cancellationTokenSource;

        public event EventHandler<double> DataReceived;

        public Altimeter()
        {
            
        }

        public void Connect()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _sensorTask = new Task(async () =>
            {

                string errmsg = "";
                int code = -1;
                code = YAPI.RegisterHub("10.0.2.60", ref errmsg);
                //YAPI.SetDeviceListValidity(3600);
                //YAPI.RegisterDeviceArrivalCallback(deviceArrival);
                code = YAPI.UpdateDeviceList(ref errmsg);
                code = YAPI.HandleEvents(ref errmsg);
                _altitude = YAltitude.FirstAltitude();
                bool online = _altitude.isOnline();
                code = _altitude.set_reportFrequency("5/s");
                code = _altitude.registerTimedReportCallback(AltitudeCallBack);

                while (true)
                {
                    await Task.Delay(1);
                    YAPI.HandleEvents(ref errmsg);
                }
            }, _cancellationTokenSource.Token);
            _sensorTask.Start();
        }

        private void AltitudeCallBack(YAltitude altitude, YMeasure measure)
        {
            double altValue = altitude.get_currentValue();
            DataReceived?.Invoke(this, altValue);
        }
    }
}

