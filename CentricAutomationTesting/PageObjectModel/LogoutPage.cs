using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class LogoutPage
    {
        IWebDriver driver;

        public LogoutPage(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement btnMenu => driver.FindElement(By.XPath("//*[@id=\"react-burger-menu-btn\"]"));
        public IWebElement btnLogOut => driver.FindElement(By.Id("logout_sidebar_link"));

        public void LogOutOffAccount()
        {
            btnMenu.Click();
            Thread.Sleep(2000);
            btnLogOut.Click();
            Thread.Sleep(2000);
        }
    }
}
