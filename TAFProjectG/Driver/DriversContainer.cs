using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TAFProjectG.Driver
{
	public class DriversContainer
	{
		public static ConcurrentDictionary<string, IWebDriver> cd =
			new ConcurrentDictionary<string, IWebDriver>();
	}
}
