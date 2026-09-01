using Microsoft.AspNetCore.Mvc;
using webApi.Repositories;

namespace webApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterControllerController(ICharacterRepo _characterRepo) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<Dtos.CharacterDto>>> GetCharacters()
    {
        return Ok(await _characterRepo.GetCharacters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dtos.CharacterDto>> GetCharacterById(int id)
    {
        try
        {
            return Ok(await _characterRepo.GetCharacterById(id));
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Character not found.");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Dtos.CharacterCreateDto>> AddCharacter(Dtos.CharacterCreateDto characterCreateDto)
    {
        var character = new model.Character
        {
            Name = characterCreateDto.Name,
            Level = characterCreateDto.Level,
            Class = characterCreateDto.Class,
            Role = characterCreateDto.Role
        };

        var newCharacter = await _characterRepo.CreateCharacter(characterCreateDto);
        return CreatedAtAction(nameof(GetCharacterById), new { id = newCharacter.Id }, newCharacter);
    }
}
