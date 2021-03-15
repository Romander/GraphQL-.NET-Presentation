using CodeFirst.Types;
using HotChocolate.AspNetCore.Extensions;
using HotChocolate.AspNetCore.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace GraphQL.Tests.Utilities
{
  public class ServerTestBase : IClassFixture<TestServerFactory>
  {
    public ServerTestBase(TestServerFactory serverFactory)
    {
      ServerFactory = serverFactory;
    }

    protected TestServerFactory ServerFactory { get; }

    protected virtual TestServer CreateStarWarsServer(
        string pattern = "/graphql",
        Action<IServiceCollection> configureServices = default,
        Action<GraphQLEndpointConventionBuilder> configureConventions = default)
    {
      return ServerFactory.Create(
          services =>
          {
            services
              .AddRouting()
              .AddHttpResultSerializer(HttpResultSerialization.JsonArray)
              .AddGraphQLServer()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddSubscriptionType<SubscriptionType>()
                .AddType<HumanType>()
                .AddType<DroidType>()
                .AddType<EpisodeType>()
              .AddExportDirectiveType()
              .AddStarWarsRepositories()
              .AddInMemorySubscriptions();

            configureServices?.Invoke(services);
          },
          app => app
              .UseWebSockets()
              .UseRouting()
              .UseEndpoints(endpoints =>
              {
                GraphQLEndpointConventionBuilder builder = endpoints.MapGraphQL(pattern);

                configureConventions?.Invoke(builder);
              }));
    }
  }
}
