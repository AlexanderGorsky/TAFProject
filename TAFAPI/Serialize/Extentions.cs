using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFAPI.Serialize
{
	public static class Extentions
	{
		public static string ToStringExt<T>(this List<T> list)
		{
			StringBuilder result = new StringBuilder();
			foreach (T item in list)
				result.AppendLine(item.ToString());
			return result.ToString();
		}
	}
}
