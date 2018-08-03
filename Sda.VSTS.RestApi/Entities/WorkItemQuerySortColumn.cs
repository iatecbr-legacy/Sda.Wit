namespace Sda.VSTS.RestApi.Entities
{
	public class WorkItemQuerySortColumn
    {
		public WorkItemFieldReference Field { get; set; }

		public bool Descending { get; set; }


		public override string ToString()
		{
			return this.Field.ToString();
		}
	}
}
