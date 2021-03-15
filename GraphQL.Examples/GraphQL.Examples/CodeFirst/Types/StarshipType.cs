using HotChocolate.Types;
using PureCodeFirst.v10.Models;
using PureCodeFirst.v10.Resolvers;

namespace PureCodeFirst.v10.Types
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
