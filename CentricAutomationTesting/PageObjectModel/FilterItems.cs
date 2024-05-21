using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class FilterItems
    {
        IWebDriver driver;

        public FilterItems(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement filterButton => driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/div/span/span"));
        public IWebElement filterChoosed => driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/div/span/select/option[3]"));

        public void FilterClicked()
        {
            filterButton.Click();
            Thread.Sleep(2000);
            filterChoosed.Click();
            Thread.Sleep(2000);
        }
    }
}
