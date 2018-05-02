using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TAFAPI.Serialize
{
	[Serializable, XmlRoot("projects")]
	public class Catalog
	{
		[XmlAttribute("type")]
		public string Type { get; set; }
		[XmlAttribute("limit")]
		public string Limit { get; set; }
		[XmlAttribute("offset")]
		public string Offset { get; set; }
		[XmlAttribute("total_count")]
		public string TotalCount { get; set; }

		[XmlElement("project")] public List<Projects> Projects { get; set; }

		public Catalog()
		{
			Projects = new List<Projects>();
		}

		public override string ToString()
		{
			return Projects.ToStringExt();
		}
	}
}
