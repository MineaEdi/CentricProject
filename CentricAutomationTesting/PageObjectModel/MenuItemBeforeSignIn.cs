using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class MenuItemBeforeSignIn : MenuItem
    {
        IWebDriver driver;

        public MenuItemBeforeSignIn(IWebDriver browser) : base(browser)
        {
            driver = browser;
        }

        IWebElement SignInLink => driver.FindElement(By.LinkText("Inregistrare"));

        public LoginPage GoToSignInPage()
        {
            SignInLink.Click();
            return new LoginPage(driver);
        }
    }
}
