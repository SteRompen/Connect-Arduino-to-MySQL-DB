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


namespace ArduinoDataToDB
{
    class Program
    {
        public static void Main()
        {
            Arduino arduino = new Arduino();
            DatabaseLogic dBLogic = new DatabaseLogic();
            Program program = new Program();


            // Validate the connection with the MySQL DB
            Console.WriteLine("Connecting to MySQL...");
            if (dBLogic.ConnectionToDBSuccessful())
            {
                Console.WriteLine("Connection with DB SUCCESFUL");
                Console.WriteLine(" ");
            }
            else
            {
                program.DisplayError("Connection with datbase NOT succesful.Please check the connection to the MySQL database you are using.");
                program.EscapeProgram();
            }

            // Validate the connection with the Arduino
            Console.WriteLine("Connecting to MySQL...");
            if (arduino.ConnectionWithArduinoSuccessful())
            {
                Console.WriteLine("Connection with Arduino SUCCESFUL");
                Console.WriteLine(" ");
                arduino.ActivateMeasurment();
            }
            else
            {
                program.DisplayError("Connection with Arduino NOT succesful. Please check the serial connection and port you are using.");
                program.EscapeProgram();
            }
        }


        private void DisplayError(string error)
        {
            Console.WriteLine("--- WARNING WARNING WARNING ---");
            Console.WriteLine("--- " + error + " ---");
        }


        private void EscapeProgram()
        {
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}

