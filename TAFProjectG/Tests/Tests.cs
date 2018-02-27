//using System.Configuration;
//using NUnit.Framework;
//using TAFProjectG.Utils;

//namespace TAFProjectG.Tests
//{
//	[TestFixture]
//	public class SmokeTests
//	{
//		private readonly Steps.Steps steps = new Steps.Steps();
//		private static readonly string Username = ConfigurationManager.AppSettings["username1"];
//		private static readonly string Password = ConfigurationManager.AppSettings["password1"];
//		readonly RandomGenerator rnd = new RandomGenerator();

//		[SetUp]
//		public void Init()
//		{
//			steps.InitBrowser();
//		}
	
//		[Test]
//		public void LoginRedmineTest()
//		{
//			steps.LoginRedmine(Username, Password);
//			Assert.True(steps.IsLoggedIn(Username));
//		}
//		//Вынести логин в отдельный класс
//		[Test]
//		public void CreateNewIssueTest()
//		{
//			steps.LoginRedmine(Username, Password);
//			string issueId = steps.CreateNewIssue(rnd.GetRandomString(6));
//			Assert.True(steps.IsIssueCreated(issueId));
//		}

//		[Test]
//		public void CreateNewProjectTest()
//		{
//			steps.LoginRedmine(Username, Password);
//			steps.CreateProject(rnd.GetRandomString(4), rnd.GetRandomString(2));
//			//Assert.True(steps.IsIssueCreated(issueId));
//		}

//		[TearDown]
//		public void Cleanup()
//		{
//			steps.CloseBrowser();
//		}
//	}
//}
