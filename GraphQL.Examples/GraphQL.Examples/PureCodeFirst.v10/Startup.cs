using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PureCodeFirst.v10.Characters;
using PureCodeFirst.v10.Repositories;
using PureCodeFirst.v10.Reviews;

namespace PureCodeFirst.v10
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // Add the custom services like repositories etc ...
      services.AddSingleton<ICharacterRepository, CharacterRepository>();
      services.AddSingleton<IReviewRepository, ReviewRepository>();

      // Add in-memory event provider
      services.AddInMemorySubscriptionProvider();

      // Add GraphQL Services
      services.AddGraphQL(sp => SchemaBuilder.New()
          .AddServices(sp)
          .AddQueryType(d => d.Name("Query"))
          .AddMutationType(d => d.Name("Mutation"))
          .AddSubscriptionType(d => d.Name("Subscription"))
          .AddType<CharacterQueries>()
          .AddType<ReviewQueries>()
          .AddType<ReviewMutations>()
          .AddType<ReviewSubscriptions>()
          .AddType<Human>()
          .AddType<Droid>()
          .AddType<Starship>()
          .Create());
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
          .UseGraphQL("/graphql");
    }
  }
}
