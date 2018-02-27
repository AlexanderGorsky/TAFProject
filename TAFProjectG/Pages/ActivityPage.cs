using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TAFProjectG.Utils;

namespace TAFProjectG.Pages
{
	public class ActivityPage
	{


		private const string BaseUrl = "http://icerow.com/activity";

		[FindsBy(How = How.Id, Using = "activity")]
		public IWebElement activityContainer;

		[FindsBy(How = How.XPath, Using = "//th[@title='Sort by \"Subject\"']")]
		public IWebElement tableSubject;

		[FindsBy(How = How.XPath, Using = "//tbody//td[@class='Subject']")]
		public ReadOnlyCollection<IWebElement> subjectContainer { get; }

		private IWebDriver driver;

		public ActivityPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(this.driver, this);
		}

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(BaseUrl);
		}

		public string GetNewIssueIdentifier()
		{
			return activityContainer.Text;
		}
	}
}
