using HotChocolate;
using HotChocolate.Types;
using PureCodeFirst.v11.Repositories;
using System.Collections.Generic;

namespace PureCodeFirst.v11.Characters
{
  /// <summary>
  /// A character in the Star Wars universe.
  /// </summary>
  [InterfaceType(Name = "Character")]
  public interface ICharacter : ISearchResult
  {
    /// <summary>
    /// The unique identifier for the character.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// The name of the character.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The ids of the character's friends.
    /// </summary>
    [GraphQLIgnore]
    IReadOnlyList<int> FriendsIds { get; }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    IEnumerable<ICharacter> GetFriends(
      [Parent] ICharacter recipent,
      [Service] ICharacterRepository characterRepository);

    /// <summary>
    /// The episodes the character appears in.
    /// </summary>
    IReadOnlyList<Episode> AppearsIn { get; }

    /// <summary>
    /// The height of the character.
    /// </summary>
    [UseConvertUnit]
    double Height { get; }
  }
}
