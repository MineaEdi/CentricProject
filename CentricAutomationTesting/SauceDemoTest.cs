using CentricAutomationTesting.PageObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CentricAutomationTesting
{
    [TestClass]
    public class SauceDemoTest
    {
        private ChromeDriver driver = new ChromeDriver();

        private HomePage homePage;
        private LoginPage loginPage;
        private LogoutPage logoutPage;

        [TestInitialize]
        public void TestInitialize()
        {
            //access the browser
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://saucedemo.com/");
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

        [TestMethod]
        public void LogOutAccount() 
        {
            LogInAccount();
            logoutPage = new LogoutPage(driver);
            logoutPage.LogOutOffAccount();

            homePage = new HomePage(driver);

            Assert.IsTrue(homePage.GetMainPageText().Contains("Accepted usernames are:"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
