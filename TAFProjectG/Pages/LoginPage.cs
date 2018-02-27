using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TAFProjectG.Utils;

namespace TAFProjectG.Pages
{
	public class LoginPage
	{
		private const string BaseUrl = "http://icerow.com/";//protected abstract prop

		[FindsBy(How = How.Id, Using = "username")]
		private IWebElement inputLogin;

		[FindsBy(How = How.Id, Using = "password")]
		private IWebElement inputPassword;

		[FindsBy(How = How.Name, Using = "login")]
		private IWebElement loginButton;

		[FindsBy(How = How.XPath, Using = "//*[@id='loggedas']/a")]
		private IWebElement loggedInUser;

		private IWebDriver driver;
		

		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(this.driver, this);
		}

		public void OpenPage()//is it need?
		{
		
			driver.Navigate().GoToUrl(BaseUrl);
			
			Logger.Log.Info($"Go to {BaseUrl}");
		}

		public LoginPage Login(string username, string password)
		{
			inputLogin.SendKeys(username);
			Logger.Log.Info($"{username} sent to username field");
			inputPassword.SendKeys(password);
			Logger.Log.Info($"{password} sent to password field");
			loginButton.Click();
			return this;
		}

		public string GetLoggedInUserName()
		{
			Logger.Log.Info($"{loggedInUser.Text} is logged in user");
			return loggedInUser.Text;
		}
	}
}
