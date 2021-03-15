using CodeFirst.Models;
using HotChocolate.Types;

namespace CodeFirst.Types
{
  public class SearchResultType
        : UnionType
  {
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
      descriptor.Name("SearchResult");
      descriptor.Type<ObjectType<Starship>>();
      descriptor.Type<HumanType>();
      descriptor.Type<DroidType>();
    }
  }
}
