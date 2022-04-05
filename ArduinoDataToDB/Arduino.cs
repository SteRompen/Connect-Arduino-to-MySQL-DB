/* 
 ---IMPORTANT---
It is important to read the README attached to this project on GitHub.
When using this code, you need to set the right serialport, in my case it was
COM7, but this will be different on every laptop/computer. Also, you will need to make
a connection to your own MySQL db. This means that the connectionstring needs to be
changed. A manual about connecting your own database can be found in the README file. 

GitHub README link: https://github.com/SteRompen/Connect-Arduino-to-MySQL-DB#readme
*/

using System;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

namespace ArduinoDataToDB
{
    class Arduino
    {
        readonly DatabaseLogic dBLogic = new DatabaseLogic();
        static SerialPort _serialPort;


        public bool ConnectionWithArduinoSuccessful()
        {
            try
            {
                _serialPort = new SerialPort
                {
                    //Set your personal COM
                    PortName = "COM7",
                    // Maybe you need to change this, check the BaudRate settings in your Arduino code!
                    BaudRate = 9600
                };
                _serialPort.Open();
                _serialPort.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void ActivateMeasurment()
        {
            _serialPort = new SerialPort
            {
                //Set your board COM
                PortName = "COM7",
                // Maybe you need to change this, check the BaudRate settings in your Arduino code
                BaudRate = 9600
            };
            _serialPort.Open();

            while (true)
            {
                string record = _serialPort.ReadExisting();
                try
                {
                    float data = float.Parse(record, CultureInfo.InvariantCulture.NumberFormat);
                    dBLogic.SaveData(data);
                    // This is the time between the readings. You can change this if you want to.
                    // NOTE: time in miliseconds, so 1 sec = 1000 for example
                    Thread.Sleep(5000);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{record}'");
                    // This is the time between the readings. You can change this if you want to.
                    // NOTE: time in miliseconds, so 1 sec = 1000 for example
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
