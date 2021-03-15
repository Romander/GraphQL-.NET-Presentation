using System.Net;

namespace GraphQL.Tests.Utilities
{
  public class ClientRawResult
  {
    public string ContentType { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public string Content { get; set; }
  }
}
