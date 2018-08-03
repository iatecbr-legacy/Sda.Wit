namespace Sda.VSTS.RestApi.Entities
{
	public class WorkItemReference
	{
		public int Id { get; set; }

		public string Url { get; set; }


		public override string ToString()
		{
			return this.Id.ToString();
		}
	}
}
