using System;
using MySql.Data.MySqlClient;

namespace YahooScraper
{
    public class ConnectSQL
    {
        static MySqlConnection con;

        public static void Connect(string user, string password)
        {
            con = new MySqlConnection();

            try
            {
                con.ConnectionString = "Server=127.0.0.1;Port=3306;Database=finance;Uid=root;Pwd=@n9Vm6#1B;";

                con.Open();
                Console.WriteLine("succesfully connected");
            }

            catch(Exception e)
            {
                Console.WriteLine("Not succesfully" + e.ToString());
            }
        }

        internal static void Connect()
        {
            con.Close();
            Console.WriteLine("hello");
        }
        
    }

}
