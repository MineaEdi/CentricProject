using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        IWebElement welcomeText => driver.FindElement(By.XPath("//span[@class='title']"));

        public string GetWelcomeText()
        {
            return welcomeText.Text;
        }
    }
}
