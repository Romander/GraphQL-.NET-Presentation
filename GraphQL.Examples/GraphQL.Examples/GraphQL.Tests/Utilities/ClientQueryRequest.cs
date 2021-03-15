using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Tests.Utilities
{
  public class ClientQueryRequest
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("operationName")]
    public string OperationName { get; set; }

    [JsonProperty("query")]
    public string Query { get; set; }

    [JsonProperty("variables")]
    public Dictionary<string, object> Variables { get; set; }

    [JsonProperty("extensions")]
    public Dictionary<string, object> Extensions { get; set; }

    public override string ToString()
    {
      var query = new StringBuilder();

      if (Id != null)
      {
        query.Append($"id={Id}");
      }

      if (Query != null)
      {
        if (Id != null)
        {
          query.Append("&");
        }
        query.Append($"query={Query.Replace("\r", "").Replace("\n", "")}");
      }

      if (OperationName != null)
      {
        query.Append($"&operationName={OperationName}");
      }

      if (Variables != null)
      {
        query.Append("&variables=" + JsonConvert.SerializeObject(Variables));
      }

      if (Extensions != null)
      {
        query.Append("&extensions=" + JsonConvert.SerializeObject(Extensions));
      }

      return query.ToString();
    }
  }
}
