using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TAFAPI.Serialize
{
	[Serializable, XmlType(TypeName = "project")]
	public class Projects
	{
		/*
		 * <id>194</id>
		   <name>!!!</name>
		   <identifier>drhf</identifier>
		   <description/>
		   <status>1</status>
		   <is_public>false</is_public>
		   <created_on>2018-02-28T13:29:29Z</created_on>
		   <updated_on>2018-02-28T13:29:29Z</updated_on>
		 */
		private DateTime createdTime, updatedTime;

		//[XmlAttribute("total_count")]public int TotalCount { get; set; }

		[XmlElement("id")] public string Id { get; set; }

		[XmlElement("name")] public string Name { get; set; }

		[XmlElement("identifier")]public string Identifier { get; set; }

		[XmlElement("description")] public string Description { get; set; }

		[XmlElement("status")] public string Status { get; set; }

		[XmlElement("is_public")] public bool IsPublic { get; set; }

		[XmlElement("created_on")]
		public DateTime CreatedOn
		{
			get { return createdTime.Date; }
			set { createdTime = value; }
		}

		[XmlElement("updated_on")] public DateTime UpdatedOn
		{
			get { return updatedTime.Date;}
			set { updatedTime = value; }
		}

		public override string ToString()
		{
			return $"Project: {Name}\n" +
			       $"Identifier is: {Identifier}\n. Description is: {Description}\n" +
			       $"Created on: {CreatedOn}\n";
		}

	}
}
