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

            Console.WriteLine("Connecting to MySQL...");
            // Validate the connection to the DB
            if (dBLogic.ConnectToMySQL())
            {
                Console.WriteLine("Connection succesful");
                arduino.ActivateMeasurment();
            }
            else
            {
                Console.WriteLine("Connection NOT succesful. Please check the connection to the " +
                "MySQL database you are using.");
            }
        }
    }





}

