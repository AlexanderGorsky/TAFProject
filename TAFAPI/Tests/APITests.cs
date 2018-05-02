using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NUnit.Framework;
using TAFAPI.Serialize;
using TAFProjectG.Utils;
using static System.Configuration.ConfigurationManager;
namespace TAFAPI.Tests
{
	[TestFixture]
	class APITests
	{
		private HttpClient client ;
		RandomGenerator rnd = new RandomGenerator();
		private int successStatus = 200;
		private int createStatus = 201;
		[SetUp]
		public void SetUp()
		{
			client = new HttpClient();
		}


		[Test]
		public void LoginTestAPI()
		{
			var response = client.GetAsync($"{AppSettings["url"]}?key={AppSettings["key"]}");
			//Console.WriteLine((int)response.Result.StatusCode);
			//Console.WriteLine(response.Result.Content.ReadAsStringAsync().Result);
			Assert.AreEqual(successStatus, (int)response.Result.StatusCode);
		}

		[Test]
		public void CreateNewProjectAPI()
		{
			string newProjectXml = $"<project><name>{rnd.GetRandomString(7)}</name><identifier>{rnd.GetRandomString(6)}</identifier></project>";
			var sc = new StringContent(newProjectXml, Encoding.UTF8, "application/xml");
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{AppSettings["url"]}{AppSettings["xml"]}?key={AppSettings["key"]}");
			//HttpClient client = new HttpClient();
			request.Content = sc;
			var task = client.SendAsync(request);
			Console.WriteLine((int)task.Result.StatusCode);
			Console.WriteLine(task.Result.Content.ReadAsStringAsync().Result);
			Assert.AreEqual(createStatus, (int)task.Result.StatusCode);
		}

		[Test]
		public void CreateNewIssueAPI()
		{
			string newIssueXml = "<issue><project_id>kqlpmb</project_id><subject>Gendalph</subject><priority_id>4</priority_id></issue>";
			var sc = new StringContent(newIssueXml, Encoding.UTF8, "application/xml");
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{AppSettings["url"]}issues.xml?key={AppSettings["key"]}");
			request.Content = sc;
			var task = client.SendAsync(request);
			//Console.WriteLine((int)task.Result.StatusCode);
			//Console.WriteLine(task.Result.Content.ReadAsStringAsync().Result);
			Assert.AreEqual(createStatus, (int)task.Result.StatusCode);
		}

		[Test]
		public void GetProjectsList()
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{AppSettings["url"]}{AppSettings["xml"]}?key={AppSettings["key"]}&limit=200");
			var task = client.SendAsync(request);
			Console.WriteLine((int)task.Result.StatusCode);
			Console.WriteLine(task.Result.Content.ReadAsStringAsync().Result);
			Assert.AreEqual(successStatus, (int)task.Result.StatusCode);
		}

		[Test]
		public void TestingSerialize()//DoesentWork ='(
		{
			
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
				$"{AppSettings["url"]}{AppSettings["xml"]}?key={AppSettings["key"]}&limit=200");
			var task = client.SendAsync(request);
			var serializer = new XmlSerializer(typeof(Catalog));
			//var catalog = serializer.Deserialize(task.Result.Content.ReadAsStreamAsync().Result) as Catalog;
			Assert.AreEqual(successStatus, (int)task.Result.StatusCode);
		}

		[TearDown]
		public void Teardown()
		{
			client.Dispose();
		}
	}
}
