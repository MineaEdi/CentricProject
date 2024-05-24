using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentricAutomationTesting.PageObjectModel
{
	public class ProductPage
	{
		IWebDriver driver;

		public ProductPage(IWebDriver browser)
		{
			driver = browser;
		}

		public IWebElement SortDropdown => driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/div/span/select"));

		/// <summary>
		/// Variables for the price sorting
		/// </summary>
		public IWebElement FirstProductPrice => driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[1]/div[2]/div[2]/div"));
		public IWebElement SecondProductPrice => driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[2]/div[2]/div[2]/div"));

		/// <summary>
		/// Variables for the name sorting
		/// </summary>

		public IWebElement FirstProductName => driver.FindElement(By.XPath("//*[@id=\"item_4_title_link\"]/div"));
		public IWebElement SecondProductName => driver.FindElement(By.XPath("//*[@id=\"item_0_title_link\"]/div"));

		public void SortProducts(string sortOrder)
		{
			var sortSelect = new SelectElement(SortDropdown);
			sortSelect.SelectByText(sortOrder);
			Thread.Sleep(2000); // Wait for sorting to complete
		}
	}
}
