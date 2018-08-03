using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sda.VSTS.RestApi.Entities
{
	public class QueryResult
	{
		public int Count { get; set; }

		[JsonProperty(PropertyName = "value")]
		public List<Query> Items { get; set; }


		public override string ToString()
		{
			return this.Count.ToString();
		}
	}
}
