using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class PlaceOrderPage
    {
        private IWebDriver driver;

        public PlaceOrderPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement PageTitle => driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span"));

        public string getPageTitle()
        {
            return PageTitle.Text;
        }
    }
}
