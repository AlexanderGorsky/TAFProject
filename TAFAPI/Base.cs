using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TAFAPI
{
	public class Base
	{

		public static HttpResponseMessage Init(string path)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, path);
			HttpClient client = new HttpClient();
			var sendAsync = client.SendAsync(request);
			return sendAsync.Result;
		}
	}
}
