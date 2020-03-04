using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace YahooScraper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-gpu");
            var driver = new ChromeDriver(@"/Users/JackieMac/Projects/YahooScraper/YahooScraper/bin", options);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
        }
    }
}

