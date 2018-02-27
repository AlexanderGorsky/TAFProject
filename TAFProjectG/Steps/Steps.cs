using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using TAFProjectG.Pages;

namespace TAFProjectG.Steps
{
	public class Steps
	{
		IWebDriver driver;
		public void InitBrowser()//not here!!!
		{
			//Choose browser. Chrome or Firefox
			driver = Driver.DriverInstance.GetInstance(ConfigurationManager.AppSettings["chromebrowser"]);
		}

		public void CloseBrowser()
		{
			Driver.DriverInstance.CloseBrowser();
		}

		public void LoginRedmine(string username, string password)
		{
			var loginPage = new LoginPage(driver);
			loginPage.OpenPage();
			loginPage.Login(username, password);
		}

		public string CreateNewIssue(string issueName)
		{
			var addIssuePage = new AddIssuePage(driver);
			addIssuePage.OpenPage();
			return addIssuePage.CreateNewIssue(issueName);
		}

		public bool IsIssueCreated(string id)
		{
			var activityPage = new ActivityPage(driver);
			activityPage.OpenPage();
			return activityPage.GetNewIssueIdentifier().Contains(id);
		}

		public void CreateProject(string nameProject, string projectIdentifier)
		{
			var addNewProject = new AddProjectPage(driver);
			addNewProject.OpenPage();
			addNewProject.CreateNewProject(nameProject, projectIdentifier);
		}

		public bool IsLoggedIn(string username)
		{
			var loginPage = new LoginPage(driver);
			return (loginPage.GetLoggedInUserName().Equals(username));
		}

		/// <summary>
		/// To sort by subject.
		/// </summary>
		public void SortBySubject()
		{
			var activityPage = new ActivityPage(driver);
			activityPage.tableSubject.Click();
		}

		public List<string> GetIssuesSubjectList()
		{
			var activityPage = new ActivityPage(driver);
			List<string> subjectList = new List<string>();
			foreach (var subjectElement in activityPage.subjectContainer)
			{
				subjectList.Add(subjectElement.Text);
			}

			return subjectList;
		}

	}
}
