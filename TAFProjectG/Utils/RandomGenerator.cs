using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFProjectG.Utils
{
	public class RandomGenerator
	{
		public string GetRandomString(int length)
		{
			string chars = "BCDFGHJKLMNPQ_RSTVWXZ0123456789";
			Random random = new Random();
			string result = new string(
				Enumerable.Repeat(chars, length)
					.Select(s => s[random.Next(s.Length)])
					.ToArray());

			return result;
		}
	}
}
