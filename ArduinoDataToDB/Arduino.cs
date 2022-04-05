using System.IO.Ports;
using System.Threading;

namespace ArduinoDataToDB
{
    class Arduino
    {
        readonly DatabaseLogic dBLogic = new DatabaseLogic();
        static SerialPort _serialPort;


        public void ActivateMeasurment()
        {
            _serialPort = new SerialPort
            {
                PortName = "COM9", //Set your board COM
                BaudRate = 9600
            };
            _serialPort.Open();

            while (true)
            {
                string record = _serialPort.ReadExisting();
                dBLogic.SaveData(record);
                Thread.Sleep(2000);
            }
        }
    }
}
