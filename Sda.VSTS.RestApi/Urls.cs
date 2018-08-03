using System;

namespace Sda.VSTS.RestApi
{
	public static class Urls
	{
		private static string project;
		private static readonly string apiVersion = "2.2";

		//public Urls(string proj)
		//{
		//	project = proj;
		//}

		public static void SetProject(string proj)
		{
			project = proj;
		}

		public static class WorkItemTracking
		{
			public static string GetQueries(string path)
			{
				return String.Format("DefaultCollection/{0}/_apis/wit/queries/{1}?api-version={2}&$depth={3}", project, path, apiVersion, 2);
			}

			public static string RunQuery(string queryId)
			{
				return String.Format("{0}/_apis/wit/wiql/{1}?api-version={2}", project, queryId, apiVersion);
			}

			public static string GetWorkItemsByIds(string ids, string asOf)
			{
				return String.Format("_apis/wit/workitems?ids={0}&asOf={1}&api-version={2}", ids, asOf, apiVersion);
			}
		}

	}
}
