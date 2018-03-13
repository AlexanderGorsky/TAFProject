using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TAFProjectG.Pages
{
	public class AddProjectPage
	{
		private const string BaseUrl = "http://icerow.com/projects/new";
		private string projectName = string.Empty;

		[FindsBy(How = How.XPath, Using = "//input[@id='project_name']")]
		private IWebElement inputProjectName;

		[FindsBy(How = How.XPath, Using = "//textarea[@id='project_description']")]
		private IWebElement inputProjectDescription;

		[FindsBy(How = How.XPath, Using = "//input[@id='project_homepage']")]
		private IWebElement inputHomepage;

		[FindsBy(How = How.XPath, Using = "//input[@id='project_is_public']")]
		private IWebElement checkboxPublic;

		[FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
		private IWebElement buttonCreate;

		[FindsBy(How = How.Id, Using = "flash_notice")]
		public readonly IWebElement isProjectCreatedNotice;

		private IWebDriver driver;

		public AddProjectPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(this.driver, this);
		}

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(BaseUrl);
		}

		public HttpRequestMessage GetResponseAddProjectPage()
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://icerow.com/projects/" + projectName + "/settings");
			return request;
		}

		public void CreateNewProject(string projectName, string projectIdentifier)
		{
			this.projectName = projectName;
			inputProjectName.SendKeys(projectName);
			inputProjectDescription.SendKeys(projectIdentifier);
			buttonCreate.Click();
		}
	}
}
