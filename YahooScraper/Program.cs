using System;

namespace YahooScraper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var conn = new ConnectSQL();
            ConnectSQL.Connect("mysql-Username", "mysql-Password");
            
            var scrape = new scrape();
            var results = scrape.scraper();
            foreach (var stock in results)
            {
                Console.WriteLine(stock);
            }
        }
    }
}

