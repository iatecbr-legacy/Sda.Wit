namespace Sda.VSTS.RestApi.Entities
{
	public class WorkItemFieldReference
    {
		public string Name { get; set; }

		public string ReferenceName { get; set; }

		public string Url { get; set; }


		public override string ToString()
		{
			return this.Name;
		}
	}
}
