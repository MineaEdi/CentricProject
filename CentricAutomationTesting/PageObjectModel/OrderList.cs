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
        public IWebElement nrOfItems => driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a/span"));
        public IWebElement btnCart => driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a"));
        public IWebElement btnCheckOut => driver.FindElement(By.Id("checkout"));
        public IWebElement btnContinue => driver.FindElement(By.Id("continue"));
        public IWebElement btnfinish => driver.FindElement(By.Id("finish"));
        public IWebElement fName => driver.FindElement(By.Id("first-name"));
        public IWebElement lName => driver.FindElement(By.Id("last-name"));
        public IWebElement code => driver.FindElement(By.Id("postal-code"));

        public void OrderCart()
        {
            firstItem.Click();
            Thread.Sleep(2000);
            secondItem.Click();
            Thread.Sleep(2000);
        }

        public void OrderCheckOut() 
        {
            if (nrOfItems.Text == "2") btnCart.Click();
            Thread.Sleep(1000);
            btnCheckOut.Click();
            Thread.Sleep(2000);
        }

        public void FillInfo(string firstName, string lastName, string zipcode)
        {
            fName.SendKeys(firstName);
            Thread.Sleep(1000);
            lName.SendKeys(lastName);
            Thread.Sleep(1000);
            code.SendKeys(zipcode);
            Thread.Sleep(1000);
            btnContinue.Click();
            Thread.Sleep(3000);
            btnfinish.Click();
        }
    }
}
