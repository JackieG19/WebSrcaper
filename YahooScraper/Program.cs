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
        
           var options = new ChromeOptions();
            options.AddArguments("--disable-gpu");
            var driver = new ChromeDriver(@"/Users/JackieMac/Projects/YahooScraper/YahooScraper/bin", options);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
            
            driver.FindElement(By.Id("header-signin-link")).Click();

            var userName = driver.FindElement(By.Name("username"));
            userName.SendKeys("throw-away-email");
            userName.Submit();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var pass = driver.FindElement(By.Id("login-passwd"));
            pass.SendKeys("throw-away-password");
            pass.Submit();
            
            // need to close 2nd tab pop-up
        }
    }
}
