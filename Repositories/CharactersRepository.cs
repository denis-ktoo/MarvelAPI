using MarvelAPI.Data;
using MarvelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        private readonly MarvelContext _context;

        public CharactersRepository(MarvelContext context)
        {
            _context = context;
        }

        public int GetCharactersCount()
        {
            return _context.Characters.Count();
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            var characters = await _context.Characters.ToListAsync();
            if (characters == null)
            {
                return null;
            }
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return null;
            }

            return character;
        }
    }
}
