using System.Collections.Generic;
using System.Linq;
using PureCodeFirst.v10.Characters;

namespace PureCodeFirst.v10.Repositories
{
    public interface ICharacterRepository
    {
        IQueryable<ICharacter> GetCharacters();

        IEnumerable<ICharacter> GetCharacters(params int[] ids);

        ICharacter GetHero(Episode episode);

        IEnumerable<ISearchResult> Search(string text);
    }
}
