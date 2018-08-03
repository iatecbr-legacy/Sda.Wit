using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sda.VSTS.RestApi.Entities
{
	public class WorkItemResult
	{
		public int Count { get; set; }

		[JsonProperty(PropertyName = "value")]
		public List<WorkItem> Items { get; set; }
	}
}
