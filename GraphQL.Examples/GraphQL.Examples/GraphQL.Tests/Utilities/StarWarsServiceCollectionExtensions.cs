using CodeFirst.Data;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GraphQL.Tests.Utilities
{
  public static class StarWarsServiceCollectionExtensions
  {
    public static IRequestExecutorBuilder AddStarWarsRepositories(
        this IRequestExecutorBuilder builder)
    {
      builder.Services.TryAddSingleton<CharacterRepository>();
      builder.Services.TryAddSingleton<ReviewRepository>();
      return builder;
    }
  }
}
