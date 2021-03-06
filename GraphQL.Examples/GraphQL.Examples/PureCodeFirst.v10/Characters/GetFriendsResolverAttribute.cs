using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using PureCodeFirst.v10.Repositories;
using System.Linq;
using System.Reflection;

namespace PureCodeFirst.v10.Characters
{
  public sealed class GetFriendsResolverAttribute
        : ObjectFieldDescriptorAttribute
  {
    public override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
      descriptor.Resolver(ctx =>
      {
        ICharacter character = ctx.Parent<ICharacter>();
        ICharacterRepository repository = ctx.Service<ICharacterRepository>();
        return repository.GetCharacters(character.Friends.ToArray());
      });
    }
  }
}