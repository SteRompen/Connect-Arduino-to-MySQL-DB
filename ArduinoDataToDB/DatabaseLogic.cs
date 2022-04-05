/* 
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

        public bool ConnectionToDBSuccessful()
        {
            //This is your personal MySQL connection string, you need to change this. 
            string _connStr = "server=localhost;user=root;database=dbcasus;port=3306;password=@ViezeDrekskeuter!";
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


        public void SaveData(float data)
        {
            Console.WriteLine("Data from Arduino: " + data);

            string _connStr = "server=localhost;user=root;database=dbcasus;port=3306;password=@ViezeDrekskeuter!";
            MySqlConnection conn = new MySqlConnection(_connStr);
            DateTime getDateTime = DateTime.Now;
            // You also need to change the INSERT statement. After 'INSERT INTO', you need to write yourDatabase.yourTable.
            string sqlInsert = "INSERT INTO dbcasus.test(measurement, timestamp) VALUES (@currentMeasurement, @currentDateTime)";

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

