using Newtonsoft.Json;
using Sda.VSTS.RestApi.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Sda.VSTS.RestApi
{
    public class WorkItemTracking
    {
        private Client client;

        public WorkItemTracking(Client client)
        {
            this.client = client;
        }

        public QueryResult GetQueries(string path = "/")
        {
            try
            {
                HttpResponseMessage result = client.Get(Urls.WorkItemTracking.GetQueries(path));

                if (result.IsSuccessStatusCode)
                {
                    var resultString = result.Content.ReadAsStringAsync().Result;

                    var queryResult = JsonConvert.DeserializeObject<QueryResult>(resultString);
                    var query = JsonConvert.DeserializeObject<Query>(resultString);

                    if (queryResult == null || (queryResult.Count == 0 && queryResult.Items == null))
                    {
                        return new QueryResult()
                        {
                            Count = query.Children.Count,
                            Items = query.Children
                        };
                    }

                    return queryResult;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Query GetQuery(string path = "/")
        {
            try
            {
                HttpResponseMessage result = client.Get(Urls.WorkItemTracking.GetQueries(path));

                if (result.IsSuccessStatusCode)
                {
                    return result.Content.ReadAsAsync<Query>().Result;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<Query> IterateQueries(List<Query> queries)
        {
            try
            {
                foreach (var item in queries)
                {
                    if (item.HasChildren && item.Children == null)
                    {
                        QueryResult children = GetAllQueries(item.Path);
                        if (children != null && children.Count > 0)
                        {
                            item.Children = children.Items;
                        }
                    }
                    else if (item.HasChildren)
                    {
                        item.Children = IterateQueries(item.Children);
                    }
                }

                return queries;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public QueryResult GetAllQueries(string path = "/")
        {
            try
            {
                QueryResult queries = GetQueries(path);

                if (queries.Count <= 0)
                {
                    throw new Exception(String.Format("Something went wrong. No queries found for path '{0}'.", path));
                }
                else
                {
                    queries.Items = IterateQueries(queries.Items);
                }

                return queries;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public WorkItemQueryResult RunQueryById(string queryId)
        {
            try
            {
                HttpResponseMessage result = client.Get(Urls.WorkItemTracking.RunQuery(queryId));

                if (result.IsSuccessStatusCode)
                {
                    return result.Content.ReadAsAsync<WorkItemQueryResult>().Result;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public WorkItemResult GetWorkItemsByIds(string ids, string asOf = "")
        {
            try
            {
                HttpResponseMessage result = client.Get(Urls.WorkItemTracking.GetWorkItemsByIds(ids, asOf));

                if (result.IsSuccessStatusCode)
                {
                    return result.Content.ReadAsAsync<WorkItemResult>().Result;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<WorkItem> GetWorkItemsByQueryId(string queryId)
        {
            try
            {
                if (String.IsNullOrEmpty(queryId)) throw new Exception("No query selected.");

                WorkItemQueryResult workItemQueryResult = RunQueryById(queryId);

                if (workItemQueryResult.WorkItems == null && workItemQueryResult.WorkItemRelations == null)
                {
                    return new List<WorkItem>();
                }

                var builder = new System.Text.StringBuilder();

                if (workItemQueryResult.QueryType == QueryTypeEnum.Flat)
                {
                    foreach (WorkItemReference item in workItemQueryResult.WorkItems)
                    {
                        builder.Append(item.Id.ToString()).Append(",");
                    }
                }
                else if (workItemQueryResult.QueryType == QueryTypeEnum.Tree || workItemQueryResult.QueryType == QueryTypeEnum.OneHop)
                {
                    IEnumerable<int> sourcesIds = workItemQueryResult.WorkItemRelations.Where(p => p.Source != null).Select(p => p.Source.Id);
                    IEnumerable<int> targetsIds = workItemQueryResult.WorkItemRelations.Select(p => p.Target.Id);

                    var childrenId = targetsIds.Except(sourcesIds);
                    builder.Append(string.Join(",", childrenId));
                }

                string ids = builder.ToString().TrimEnd(new char[] { ',' });

                return GetWorkItemsByIds(ids, workItemQueryResult.AsOf).Items;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
