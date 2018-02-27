using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TAFProjectG.Utils;

namespace TAFProjectG.Driver
{
	public class DriverInstance//rename to DriverFactory
	{
		private static IWebDriver driver;
		private DriverInstance() { }

		public static IWebDriver GetInstance(string appSetting)
		{
			//do enums to choose browser

			if (driver != null) return driver;
			if(appSetting == "chrome")
			driver = new ChromeDriver();
			if (appSetting == "firefox")
			{
				driver = new FirefoxDriver();
			}
			//driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
			driver.Manage().Window.Maximize();
			return driver;
		}

		public static void CloseBrowser()
		{
			driver.Quit();
			driver = null;
		}
	}
}
