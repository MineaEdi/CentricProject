using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
    public class MenuItem
    {
        private IWebDriver driver;

        public MenuItem(IWebDriver browser)
        {
            driver = browser;
        }
    }
}
