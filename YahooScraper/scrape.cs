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

            //var row = driver.FindElementByXPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[1]").Text;

            //List<string> rowTable = new List<string>();
            //return rowTable;
            //Console.WriteLine(row);
            
            //List <IWebElement> list = driver.FindElements(By.TagName("tr"));
            IReadOnlyCollection<IWebElement> list = driver.FindElements(By.TagName("tr"));
            int count = list.Count();
            //Console.WriteLine(count);

            List<string> rowTable = new List<string>();

            for (int i = 1; i <= count; i++)
            {
                //Console.WriteLine(i);
                var symbol = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[1]")).Text;
                Console.WriteLine(symbol);

                var lastPrice = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[2]")).Text;
                Console.WriteLine(lastPrice);

                var Change = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                Console.WriteLine(Change);

                var chgPercent = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;
                Console.WriteLine(chgPercent);

                var currency = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[5]")).Text;
                Console.WriteLine(currency);

                var MarketTime = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[6]")).Text;
                Console.WriteLine(MarketTime);

                var volume = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[7]")).Text;
                Console.WriteLine(volume);

                var avgVolume = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[9]")).Text;
                Console.WriteLine(avgVolume);

                var MarketCap = driver.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table/tbody/tr[" + i + "]/td[13]")).Text;
                Console.WriteLine(MarketCap);
            }
            return rowTable;
        }
    }
}
