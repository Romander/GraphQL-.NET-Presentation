using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;
using HotChocolate.AspNetCore;
using PureCodeFirst.v11.Characters;
using PureCodeFirst.v11.Repositories;
using PureCodeFirst.v11.Reviews;

namespace PureCodeFirst.v11
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // Add GraphQL Services
      services
          // Add the custom services like repositories etc ...
          .AddSingleton<ICharacterRepository, CharacterRepository>()
          .AddSingleton<IReviewRepository, ReviewRepository>()

          // configure the schema
          .AddGraphQLServer()
          .AddQueryType(d => d.Name("Query"))
            .AddType<CharacterQueries>()
            .AddType<ReviewQueries>()
          .AddMutationType(d => d.Name("Mutation"))
            .AddType<ReviewMutations>()
          .AddSubscriptionType(d => d.Name("Subscription"))
            .AddType<ReviewSubscriptions>()
          .AddType<Human>()
          .AddType<Droid>()
          .AddType<Starship>()

          // Add in-memory event provider
          .AddInMemorySubscriptions()

          .AddApolloTracing()

          // Adds support for filtering
          .AddFiltering()
          .AddSorting();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app
          .UseRouting()
          .UseWebSockets()
          .UsePlayground()
          .UseEndpoints(endpoints => endpoints.MapGraphQL());
    }
  }
}
