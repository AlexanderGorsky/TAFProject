using System.Configuration;
using System.Net.Http;
using NUnit.Framework;
using OpenQA.Selenium;
using TAFProjectG.Driver;
using TAFProjectG.Pages;
using TAFProjectG.Utils;

namespace TAFProjectG.Tests
{
	[TestFixture]
	public class SmokeTests
	{
		private HttpClient client = new HttpClient();

		private IWebDriver garb;
		private IWebDriver driver;
		DriverInstance di = new DriverInstance();
		private readonly Steps.Steps steps = new Steps.Steps();
		private static readonly string Username = ConfigurationManager.AppSettings["username1"];
		private static readonly string Password = ConfigurationManager.AppSettings["password1"];
		readonly RandomGenerator rnd = new RandomGenerator();

		[SetUp]
		public void Init()
		{
			driver = di.GetInstance(ConfigurationManager.AppSettings["browser"], driver);
			DriversContainer.cd.TryAdd(TestContext.CurrentContext.Test.Name, driver);
			Logger.InitLogger();
		}

		[Test, Parallelizable]
		public void LoginRedmineTest()
		{
			LoginPage loginPage = new LoginPage(driver);
			var sendAsync = client.SendAsync(loginPage.GetResponseLoginPage());
			var response = sendAsync.Result;
			Logger.Log.Info("login test started");
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			steps.LoginRedmine(driver, Username, Password);
			Assert.AreEqual(Username, steps.IsLoggedIn());
			Assert.IsTrue(response.Content.ReadAsStringAsync().Result.Contains("<title>icerow - Redmine</title>"));

		}

		[Test, Parallelizable]
		public void LoginRedmineTest2()
		{
			Logger.Log.Info("login test started");
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			steps.LoginRedmine(driver, "TAT18TEST", "tat18test");
			Assert.AreEqual(Username, steps.IsLoggedIn());
		}

		[Test, Parallelizable]
		public void LoginRedmineTest3()
		{
			Logger.Log.Info("login test started");
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			steps.LoginRedmine(driver, Username, Password);
			Assert.AreEqual(Username, steps.IsLoggedIn());
		}

		[Test, Parallelizable]
		public void LoginRedmineTest4()
		{
			Logger.Log.Info("login test started");
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			steps.LoginRedmine(driver, Username, Password);
			Assert.AreEqual(Username, steps.IsLoggedIn());
		}

		[Test, Parallelizable]
		public void LoginRedmineTest5()
		{
			Logger.Log.Info("login test started");
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			steps.LoginRedmine(driver, Username, Password);
			Assert.AreEqual(Username, steps.IsLoggedIn());
		}

		[Test, Parallelizable]
		public void CreateNewIssueTest()
		{
			AddIssuePage addIssuePage = new AddIssuePage(driver);

			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			steps.LoginRedmine(driver, Username, Password);
			var issueId = steps.CreateNewIssue(rnd.GetRandomString(6));
			var sendAsync = client.SendAsync(addIssuePage.GetResponseAddIssuePage());
			var response = sendAsync.Result;
			Assert.True(steps.IsIssueCreated(issueId));
			Assert.AreEqual((int)response.StatusCode, 200);
		}

		[Test, Parallelizable]
		public void CreateNewProjectTest()
		{
			AddProjectPage addProjectPage = new AddProjectPage(driver);
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			steps.LoginRedmine(driver, Username, Password);
			steps.CreateProject(rnd.GetRandomString(4), rnd.GetRandomString(2));
			var sendAsync = client.SendAsync(addProjectPage.GetResponseAddProjectPage());
			var response = sendAsync.Result;
			Assert.True(steps.IsProjectCreated());
			Assert.AreEqual((int)response.StatusCode, 200);

		}

		[TearDown]
		public void Cleanup()
		{
			DriversContainer.cd.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);
			//BaseTest.cd.TryRemove(TestContext.CurrentContext.Test.Name, out garb);
			driver.Quit();
			driver = null;
		}
	}
}
