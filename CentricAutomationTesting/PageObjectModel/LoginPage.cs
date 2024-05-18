using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement Username => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement btnLogIn => driver.FindElement(By.Id("login-button"));

        public void LogInToAccount(string username, string password)
        {
            Username.SendKeys(username);
            Thread.Sleep(1000);
            Password.SendKeys(password);
            Thread.Sleep(1000);
            btnLogIn.Click();
        }
    }
}
