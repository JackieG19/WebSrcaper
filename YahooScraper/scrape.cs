using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YahooScrapper;

namespace YahooScraper
{
    public class scrape
    {
        public List<string> scraper()
        {
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
            pass.SendKeys(Keys.Enter);
            
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolios");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElementByXPath("//*[@id='Nav-0-DesktopNav']/div/div[3]/div/nav/ul/li[2]/a").Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var watchList = driver.FindElementByXPath("//*[@id='Col1-0-Portfolios-Proxy']/main/table/tbody/tr[1]/td[1]/div[2]/a");
            watchList.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var stock = driver.FindElementsByXPath("//*[@id='pf-detail-table']/div[1]/table/tbody");

            List<string> financestocks = new List<string>();
            foreach (var stocks in stock)
            {
               financestocks.Add(stocks.Text);
            }
            return financestocks;
        }
    }
}
