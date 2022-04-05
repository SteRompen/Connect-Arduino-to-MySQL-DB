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


namespace ArduinoDataToDB
{
    class Program
    {
        public static void Main()
        {
            Arduino arduino = new Arduino();
            DatabaseLogic dBLogic = new DatabaseLogic();
            Program program = new Program();


            Console.WriteLine("Connecting to MySQL...");
            // Validate the connection to the DB
            if (dBLogic.ConnectToMySQL())
            {
                Console.WriteLine("Connection with DB SUCCESFUL");
                Console.WriteLine(" ");
            }
            else
            {
                program.DisplayError("Connection with DB NOT succesful.Please check the connection to the MySQL database you are using.");
                program.EscapeProgram();
            }

            // Validate the connection with the Arduino
            Console.WriteLine("Connecting to MySQL...");
            if (arduino.ValidateConnection())
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

