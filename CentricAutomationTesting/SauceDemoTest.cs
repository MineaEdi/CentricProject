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
		private OrderList order;
		private ProductPage productPage;

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

		[TestMethod]
		public void LogInFullOrder()
		{
			LogInAccount();
			order = new OrderList(driver);

			order.OrderCart();

			order.OrderCheckOut();

			order.FillInfo("Anton", "Beton", "123456");

			homePage = new HomePage(driver);

			Assert.IsTrue(homePage.GetOrderFinishText().Contains("Thank you for your order!"));
		}

		[TestMethod]
		public void SortProductsAscDesc()
		{
			LogInAccount();

			productPage = new ProductPage(driver);

			productPage.SortDropdown.Click();
			productPage.SortProducts("Price (low to high)");

			double firstPrice = Convert.ToDouble(productPage.FirstProductPrice.Text.Replace("$", ""));
			double secondPrice = Convert.ToDouble(productPage.SecondProductPrice.Text.Replace("$", ""));

			Thread.Sleep(3000);


			Assert.IsTrue(firstPrice < secondPrice);
		}

		[TestMethod]
		public void SortProductsDescAsc()
		{
			LogInAccount();

			productPage = new ProductPage(driver);

			productPage.SortDropdown.Click();
			productPage.SortProducts("Price (high to low)");

			double firstPrice = Convert.ToDouble(productPage.FirstProductPrice.Text.Replace("$", ""));
			double secondPrice = Convert.ToDouble(productPage.SecondProductPrice.Text.Replace("$", ""));

			Thread.Sleep(3000);


			Assert.IsTrue(firstPrice > secondPrice);
		}


		[TestMethod]
		public void TestSortProductsAToZ()
		{
			LogInAccount();

			productPage = new ProductPage(driver);

			productPage.SortDropdown.Click();
			productPage.SortProducts("Name (A to Z)");

			string firstProductName = productPage.FirstProductName.Text;
			string secondProductName = productPage.SecondProductName.Text;

			Thread.Sleep(3000);

			Assert.IsTrue(string.Compare(firstProductName, secondProductName) < 0);
		}


		/// <summary>
		/// To be verified: The Assert is failing, but the method works fine
		/// </summary>
		[TestMethod]
		public void TestSortProductsZToA()
		{
			LogInAccount();
			productPage = new ProductPage(driver);

			productPage.SortDropdown.Click();
			productPage.SortProducts("Name (Z to A)");

			string firstProductName = productPage.FirstProductName.Text;
			string secondProductName = productPage.SecondProductName.Text;

			Thread.Sleep(3000);

			Assert.IsTrue(firstProductName.CompareTo(secondProductName) > 0);

			//Assert.IsTrue(string.Compare(firstProductName, secondProductName) > 0);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			Thread.Sleep(3000);
			driver.Quit();
		}
	}
}
