using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace TAFProjectG.Pages
{
	public class LoginPage
	{
		private const string BaseUrl = "http://icerow.com/";

		[FindsBy(How = How.Id, Using = "username")]
		private IWebElement inputLogin;

		[FindsBy(How = How.Id, Using = "password")]
		private IWebElement inputPassword;

		[FindsBy(How = How.Name, Using = "login")]
		private IWebElement loginButton;

		[FindsBy(How = How.XPath, Using = "//*[@id='loggedas']/a")]
		private IWebElement loggedInUser;

		
		public IWebDriver driver;

		public LoginPage(IWebDriver driver)
		{
			
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		public void OpenPage(IWebDriver driver)
		{
			driver.Navigate().GoToUrl(BaseUrl);
			Logger.Log.Info($"Go to {BaseUrl}");
		}

		public HttpRequestMessage GetResponseLoginPage()
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);
			return request;
		}

		public void FillUsernameField(string username)
		{
			inputLogin.SendKeys(username);
			Logger.Log.Info($"{username} sent to username field");
		}

		public void FillPasswordField(string password)
		{
			inputPassword.SendKeys(password);
			Logger.Log.Info($"{password} sent to password field");
		}


		public void ClickButtonToLogIn()
		{
			Actions action = new Actions(driver);
			action.MoveToElement(loginButton);
			loginButton.Click();
		}
		
		public string GetLoggedInUserName()
		{
			Logger.Log.Info($"{loggedInUser.Text} is logged in user");
			return loggedInUser.Text;
		}
	}
}
