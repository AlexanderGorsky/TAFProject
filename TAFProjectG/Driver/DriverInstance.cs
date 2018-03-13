using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TAFProjectG.Driver
{
	public class DriverInstance
	{
		public IWebDriver GetInstance(string appSetting, IWebDriver driver)
		{
			//if (driver != null) return driver;
			switch (appSetting)
			{
				case "chrome":
					driver = new ChromeDriver();
					break;
				case "firefox":
					driver = new FirefoxDriver();
					break;
			}
			//driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
			driver.Manage().Window.Maximize();
			return driver;
		}

		//public void CloseBrowser(IWebDriver driver)
		//{
		//	driver.Quit();
		//	driver = null;
		//}
	}
}
