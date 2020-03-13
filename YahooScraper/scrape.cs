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

            IReadOnlyCollection<IWebElement> list = driver.FindElements(By.TagName("tr"));
            int count = list.Count();

            List<string> Stocks = new List<string>();

            for (int i = 1; i <= count; i++)
            {
                var symbol = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[1]")).Text;
                var lastPrice = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[2]")).Text;
                var Change = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                var chgPercent = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;
                var currency = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[5]")).Text;
                var MarketTime = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[6]")).Text;
                var volume = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[7]")).Text;
                var avgVolume = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[9]")).Text;
                var MarketCap = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[13]")).Text;
                
                Stock stock = new Stock();

                stock.symbol = symbol;
                Console.WriteLine(symbol);

                stock.lastPrice = lastPrice;
                Console.WriteLine(lastPrice);

                stock.Change = Change;
                Console.WriteLine(Change);

                stock.chgPercent = chgPercent;
                Console.WriteLine(chgPercent);

                stock.currency = currency;
                Console.WriteLine(currency);

                stock.MarketTime = MarketTime;
                Console.WriteLine(MarketTime);

                stock.volume = volume;
                Console.WriteLine(volume);

                stock.avgVolume = avgVolume;
                Console.WriteLine(avgVolume);

                stock.MarketCap = MarketCap;
                Console.WriteLine(MarketCap);

                Stocks.Add(stock.ToString());
            }
            return Stocks;
        }
    }
}
