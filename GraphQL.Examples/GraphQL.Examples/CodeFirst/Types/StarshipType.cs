using CodeFirst.Models;
using CodeFirst.Resolvers;
using HotChocolate.Types;

namespace CodeFirst.Types
{
  public class StarshipType
        : ObjectType<Starship>
  {
    protected override void Configure(IObjectTypeDescriptor<Starship> descriptor)
    {
      descriptor.Field(t => t.Id)
          .Type<NonNullType<IdType>>();

      descriptor.Field<SharedResolvers>(t => t.GetLength(default, default));
    }
  }
}
