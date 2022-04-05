﻿/* 
 ---IMPORTANT---
It is important to read the README attached to this project on GitHub.
When using this code, you need to set the right serialport, in my case it was
COM7, but this will be different on every laptop/computer. Also, you will need to make
a connection to your own MySQL db. This means that the connectionstring needs to be
changed. A manual about connecting your own database can be found in the README file. 

GitHub README link: https://github.com/SteRompen/Connect-Arduino-to-MySQL-DB#readme
*/

using MySql.Data.MySqlClient;
using System;

namespace ArduinoDataToDB
{
    class DatabaseLogic
    {
        /* 
        * This bool validates the connection between this program and the datbase. If there is 
        * no valid connection, the user gets an error about this. 
        */
        public bool ConnectionToDBSuccessful()
        {
            //This is your personal MySQL connection string, you need to change this. 
            string _connStr = "server=localhost;user=testuser;database=testdb;port=3306;password=@Zuyd2022!";
            MySqlConnection conn = new MySqlConnection(_connStr);

            // Try to make a connection with the DB from the string above
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            // Error catch when connection is unvalid
            catch (Exception err)
            {
                // Show the error that occured 
                Console.WriteLine(err.ToString());
                conn.Close();
                return false;
            }
        }


        /* After each succesful reading done by the Arduino, the data gets saved in the database. 
         * This function saves the reading and attaches a timestamp to You can add more properties to it
         * if you want to, but make sure to add them also to the table in the DB. Otherwise, the program 
         * will crash because of a non existing part in the table. 
         */
        public void SaveData(float data)
        {
            Console.WriteLine("Data from Arduino: " + data);

            string _connStr = "server=localhost;user=testuser;database=testdb;port=3306;password=@Zuyd2022!";
            MySqlConnection conn = new MySqlConnection(_connStr);
            DateTime getDateTime = DateTime.Now;
            // You also need to change the INSERT statement. After 'INSERT INTO', you need to write yourDatabase.yourTable.
            string sqlInsert = "INSERT INTO testdb.test(measurement, timestamp) VALUES (@currentMeasurement, @currentDateTime)";

            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conn))
            {
                _ = cmd.Parameters.AddWithValue("@currentMeasurement", data);
                _ = cmd.Parameters.AddWithValue("@currentDateTime", getDateTime);
                _ = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}

