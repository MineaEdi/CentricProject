using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class OrderList
    {
        IWebDriver driver;

        public OrderList(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement firstItem => driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
        public IWebElement secondItem => driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));

        public void OrderCart()
        {
            firstItem.Click();
            Thread.Sleep(2000);
            secondItem.Click();
            Thread.Sleep(2000);
        }
    }
}
