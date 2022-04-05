using System.IO.Ports;
using System.Threading;

namespace ArduinoDataToDB
{
    class Arduino
    {
        readonly DatabaseLogic dBLogic = new DatabaseLogic();
        static SerialPort _serialPort;


        public bool ValidateConnection()
        {
            try
            {
                _serialPort = new SerialPort
                {
                    //Set your personal COM
                    PortName = "COM9",
                    // Maybe you need to change this, check the BaudRate settings in your Arduino code!
                    BaudRate = 9600
                };
                _serialPort.Open();
                _serialPort.Close();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public void ActivateMeasurment()
        {
            _serialPort = new SerialPort
            {
                //Set your board COM
                PortName = "COM9", 
                // Maybe you need to change this, check the BaudRate settings in your Arduino code
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
