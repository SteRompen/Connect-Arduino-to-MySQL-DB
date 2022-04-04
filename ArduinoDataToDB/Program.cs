/* 
 ---IMPORTANT---
It is important to read the README attached to this project on GitHub.
When using this code, you need to set the right serialport, in my case it was
COM7 (see line 24), but this will be different on every laptop/computer. Also,
you will need to make a connection to your own MySQL db. A manual about connecting 
your own database can be found in the README file. 

GitHub link: 
*/ 

using System;
using System.IO.Ports;
using System.Threading;

namespace ArduinoDataToDB
{
    class Program
    {
        static SerialPort _serialPort;
        public static void Main()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM7"; //Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            while (true)
            {
                string record = _serialPort.ReadExisting();
                Console.WriteLine(record);
                Thread.Sleep(200);
            }
        }
    }
}
