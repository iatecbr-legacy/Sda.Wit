using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sda.VSTS.RestApi.Entities
{
	public class Query
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Path { get; set; }

		public CreatedBy CreatedBy { get; set; }

		public string CreatedDate { get; set; }

		public LastModifiedBy LastModifiedBy { get; set; }

		public string LastModifiedDate { get; set; }

		public bool IsFolder { get; set; }

		public bool HasChildren { get; set; }

		public List<Query> Children { get; set; }

		public bool IsPublic { get; set; }

		[JsonProperty(PropertyName = "_links")]
		public Links Links { get; set; }

		public string Url { get; set; }


		public override string ToString()
		{
			return this.Name;
		}
	}
}
