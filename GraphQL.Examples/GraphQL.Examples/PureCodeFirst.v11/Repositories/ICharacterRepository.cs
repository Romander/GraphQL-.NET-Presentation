using System.Collections.Generic;
using System.Linq;
using PureCodeFirst.v11.Characters;

namespace PureCodeFirst.v11.Repositories
{
    public interface ICharacterRepository
    {
        IQueryable<ICharacter> GetCharacters();

        IEnumerable<ICharacter> GetCharacters(params int[] ids);

        ICharacter GetHero(Episode episode);

        IEnumerable<ISearchResult> Search(string text);
    }
}
