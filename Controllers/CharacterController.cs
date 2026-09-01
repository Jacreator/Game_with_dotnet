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
    public async Task<ActionResult<model.Character>> AddCharacter(model.Character character)
    {
        var newCharacter = await _characterRepo.AddCharacter(character);
        return CreatedAtAction(nameof(GetCharacterById), new { id = newCharacter.Id }, newCharacter);
    }
}
