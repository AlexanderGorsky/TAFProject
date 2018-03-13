using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TAFProjectG.Pages
{
	public class AddIssuePage
	{
		private const string BaseUrl = "http://icerow.com/issues/new";

		[FindsBy(How = How.XPath, Using = "//div[@class='contextual']/a")]
		private IWebElement newIssueButon;

		[FindsBy(How = How.XPath, Using = "//input[@id='issue_subject']")]
		private IWebElement newIssueSubject;

		[FindsBy(How = How.Name, Using = "commit")]
		private IWebElement newIssueCommitButton;

		[FindsBy(How = How.XPath, Using = "//div[@id='flash_notice']/a")]
		private IWebElement newIssueNumber;//this one create later

		private IWebDriver driver;
		public AddIssuePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(this.driver, this);
		}

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(BaseUrl);
			Logger.Log.Info($"Go to {BaseUrl}");
		}

		public string CreateNewIssue(string issueName)
		{
			newIssueSubject.SendKeys(issueName);
			Logger.Log.Info($"{issueName} sent to issue name field");
			newIssueCommitButton.Click();
			Logger.Log.Info($"{GetIssueIdentifier()} is issue identifier");
			return GetIssueIdentifier();
		}

		public HttpRequestMessage GetResponseAddIssuePage()
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + GetIssueIdentifier().Substring(1));
			return request;
		}

		public string GetIssueIdentifier()
		{

			return newIssueNumber.Text;
		}

		public bool IsExist()
		{
			return newIssueSubject != null;
		}
	}
}
