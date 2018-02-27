using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TAFProjectG.Utils;

namespace TAFProjectG.Pages
{
	public class AddProjectPage
	{
		private const string BaseUrl = "http://icerow.com/projects/new";

		//private BaseElement inputProjectName = new BaseElement(By.XPath("//input[@id='project_name']"));

		[FindsBy(How = How.XPath, Using = "//input[@id='project_name']")]
		private IWebElement inputProjectName;
		//private BaseElement inputProjectDescription = new BaseElement(By.XPath("//textarea[@id='project_description']"));

		[FindsBy(How = How.XPath, Using = "//textarea[@id='project_description']")]
		private IWebElement inputProjectDescription;
		//private BaseElement inputHomepage = new BaseElement(By.XPath("//input[@id='project_homepage']"));

		[FindsBy(How = How.XPath, Using = "//input[@id='project_homepage']")]
		private IWebElement inputHomepage;
		//private BaseElement checkboxPublic = new BaseElement(By.XPath("//input[@id='project_is_public']"));

		[FindsBy(How = How.XPath, Using = "//input[@id='project_is_public']")]
		private IWebElement checkboxPublic;
		//private BaseElement checkboxInheritMembers = new BaseElement(By.XPath("//input[@id='project_inherit_members']"));

		[FindsBy(How = How.XPath, Using = "//input[@id='project_inherit_members']")]
		private IWebElement checkboxInheritMembers;
		//private BaseElement buttonCreate = new BaseElement(By.XPath("//input[@type='submit']"));

		[FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
		private IWebElement buttonCreate;

		private IWebDriver driver;

		//Logger logger = new Logger();

		public AddProjectPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(this.driver, this);
		}

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(BaseUrl);
		//	logger.WriteLog($"Go to {BaseUrl}");
		}

		public void CreateNewProject(string projectName, string projectIdentifier)
		{
			inputProjectName.SendKeys(projectName);
		//	logger.WriteLog($"{projectName} is name of project");
			inputProjectDescription.SendKeys(projectIdentifier);
		//	logger.WriteLog($"{projectIdentifier} is project identifier");
			//inputProjectDescription.SendKeys(projectDescription);
			//inputProjectDescription.SendKeys(homepage);
			buttonCreate.Click();
		}

	}
}
