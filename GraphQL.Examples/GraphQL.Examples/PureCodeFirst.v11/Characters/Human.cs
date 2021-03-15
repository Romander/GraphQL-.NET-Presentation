using HotChocolate;
using HotChocolate.Types;
using PureCodeFirst.v11.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PureCodeFirst.v11.Characters
{
  /// <summary>
  /// A human character in the Star Wars universe.
  /// </summary>
  public class Human : ICharacter
  {
    public Human(
        int id,
        string name,
        IReadOnlyList<int> friends,
        IReadOnlyList<Episode> appearsIn,
        string? homePlanet = null,
        double height = 1.72d)
    {
      Id = id;
      Name = name;
      FriendsIds = friends;
      AppearsIn = appearsIn;
      HomePlanet = homePlanet;
      Height = height;
    }

    /// <inheritdoc />
    public int Id { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    [GraphQLIgnore]
    public IReadOnlyList<int> FriendsIds { get; }

    /// <inheritdoc />
    public IReadOnlyList<Episode> AppearsIn { get; }

    /// <summary>
    /// The planet the character is originally from.
    /// </summary>
    public string? HomePlanet { get; }

    /// <inheritdoc />
    [UseConvertUnit]
    public double Height { get; }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IEnumerable<ICharacter> GetFriends([Parent] ICharacter recipent, [Service] ICharacterRepository characterRepository)
    {
      return characterRepository.GetCharacters(recipent.FriendsIds.ToArray());
    }
  }
}
