using MySql.Data.MySqlClient;
using System;

namespace ArduinoDataToDB
{
    class DatabaseLogic
    {
        public string _connStr;


        public bool ConnectToMySQL()
        {
            //This is your personal MySQL connection string, you need to change this. 
            _connStr = "server=localhost;user=root;database=dbcasus;port=3306;password=@ViezeDrekskeuter!";
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


        public void SaveData(string data)
        {
            Console.WriteLine("Data from Arduino: " + data);

        }
    }
}

