﻿using CodeFirst.Models;
using CodeFirst.Resolvers;
using HotChocolate.Types;

namespace CodeFirst.Types
{
  public class HumanType
        : ObjectType<Human>
  {
    protected override void Configure(IObjectTypeDescriptor<Human> descriptor)
    {
      descriptor.Interface<CharacterType>();

      descriptor.Field(t => t.Id)
          .Type<NonNullType<IdType>>();

      descriptor.Field(t => t.AppearsIn)
          .Type<ListType<EpisodeType>>();

      descriptor.Field<SharedResolvers>(r => r.GetCharacter(default, default))
          .UsePaging<CharacterType>()
          .Name("friends");

      descriptor.Field<SharedResolvers>(t => t.GetHeight(default, default))
          .Type<FloatType>()
          .Argument("unit", a => a.Type<EnumType<Unit>>())
          .Name("height");
    }
  }
}
