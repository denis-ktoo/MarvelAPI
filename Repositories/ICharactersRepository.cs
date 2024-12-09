using MarvelAPI.Models;
using System.Collections.Generic;

namespace MarvelAPI.Repositories
{
    public interface ICharactersRepository
    {
        int GetCharactersCount();
        Task<IEnumerable<Character>> GetCharacters();
        Task<Character> GetCharacterById(int id);
    }
}