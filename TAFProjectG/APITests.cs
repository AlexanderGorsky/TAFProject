using System;
using System.Net.Http;
using NUnit.Framework;

namespace TAFProjectG
{
	[TestFixture]
	class APITests
	{
		[Test]
		public void Meth()
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://icerow.com/");
			HttpClient client = new HttpClient();
			var sendAsync = client.SendAsync(request);
			var response = sendAsync.Result;
			//response.Content.Headers.ToString();
			Assert.IsTrue(response.Content.ReadAsStringAsync().Result.Contains("<title>icerow - Redmine</title>"));
			Console.WriteLine((int)response.StatusCode);
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);
		}
	}
}
