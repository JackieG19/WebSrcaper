using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace YahooScrapper
{
    public class stocks
    {
        public string symbol { get; set; }

        public string lastPrice { get; set; }

        public string Change { get; set; }

        public string chgPercent { get; set; }

        public string currency { get; set; }

        public DateTime MarketTime { get; set; }

        public string volume { get; set; }

        public string avgVolume { get; set; }

        public string MarketCap { get; set; }
    }
}
