using System.Collections.Generic;

namespace Sda.VSTS.RestApi.Entities
{
	public class WorkItemQueryResult
	{
		public string AsOf { get; set; }

		public List<WorkItemFieldReference> Columns { get; set; }

		public QueryResultTypeEnum QueryResultType { get; set; }

		public QueryTypeEnum QueryType { get; set; }

		public List<WorkItemQuerySortColumn> SortColumns { get; set; }

        public List<WorkItemLink> WorkItemRelations { get; set; }

        public List<WorkItemReference> WorkItems { get; set; }
	}
}
