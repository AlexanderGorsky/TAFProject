using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TAFProjectG.Pages
{
	public class ActivityPage
	{
		private const string BaseUrl = "http://icerow.com/activity";

		[FindsBy(How = How.Id, Using = "activity")]
		public IWebElement activityContainer;
		
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
