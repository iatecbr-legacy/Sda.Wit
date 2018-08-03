using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.VSTS.RestApi.Entities
{
   public class WorkItemLink
    {
        [JsonProperty("rel")]
        public string Relation { get; set; }

        public WorkItemReference Source { get; set; }

        public WorkItemReference Target { get; set; }
    }
}
