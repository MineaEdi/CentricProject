using CentricAutomationTesting.PageObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CentricAutomationTesting
{
    [TestClass]
    public class OkaziiTest
    {
        private ChromeDriver driver = new ChromeDriver();

        private MenuItemBeforeSignIn menuItemBeforeSignIn;
        private HomePage homePage;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            //access the browser
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://saucedemo.com/");

            menuItemBeforeSignIn = new MenuItemBeforeSignIn(driver);
        }

        [TestMethod]
        public void LogInAccount()
        {
            loginPage = new LoginPage(driver);
            Thread.Sleep(2000);
            loginPage.LogInToAccount("standard_user", "secret_sauce");
            Thread.Sleep(2000);

            homePage = new HomePage(driver);

            Assert.IsTrue(homePage.GetWelcomeText().Contains("Products"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
