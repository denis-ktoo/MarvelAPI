using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarvelAPI.Models;
using MarvelAPI.Data;
using MarvelAPI.Repositories;

namespace MarvelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersRepository _charactersRepository;

        public CharactersController(ICharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            var CharacterDtos = await _charactersRepository.GetCharacters();
            return Ok(CharacterDtos);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var characterDto = await _charactersRepository.GetCharacterById(id);

            if (characterDto == null)
            {
                return NotFound();
            }

            return Ok(characterDto);
        }
    }
}