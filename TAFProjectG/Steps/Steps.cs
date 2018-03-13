using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TAFProjectG.Driver;
using TAFProjectG.Pages;

namespace TAFProjectG.Steps
{
	public class Steps
	{
		public void LoginRedmine(IWebDriver driver, string username, string password)
		{
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			var loginPage = new LoginPage(driver);
			loginPage.OpenPage(driver);
			loginPage.FillUsernameField(username);
			loginPage.FillPasswordField(password);
			loginPage.ClickButtonToLogIn();
		}

		public bool IsProjectCreated()
		{
			IWebDriver driver;
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			var addProjectPage = new AddProjectPage(driver);
			return addProjectPage.isProjectCreatedNotice.Text.Equals("Successful creation.");
		}

		public string CreateNewIssue(string issueName)
		{
			IWebDriver driver;
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver); 
			var addIssuePage = new AddIssuePage(driver);
			addIssuePage.OpenPage();
			return addIssuePage.CreateNewIssue(issueName);
		}

		public bool IsIssueCreated(string id)
		{
			IWebDriver driver;
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			var activityPage = new ActivityPage(driver);
			activityPage.OpenPage();
			return activityPage.GetNewIssueIdentifier().Contains(id);
		}

		public void CreateProject(string nameProject, string projectIdentifier)
		{
			IWebDriver driver;
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			var addNewProject = new AddProjectPage(driver);
			addNewProject.OpenPage();
			addNewProject.CreateNewProject(nameProject, projectIdentifier);
		}

		public string IsLoggedIn()
		{
			IWebDriver driver;
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			var loginPage = new LoginPage(driver);
			return loginPage.GetLoggedInUserName();
		}
	}
}
