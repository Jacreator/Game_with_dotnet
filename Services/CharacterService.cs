using Microsoft.EntityFrameworkCore;
using webApi.Repositories;
using webApi.Data;

namespace webApi.Services;

public class CharacterService(AppDbContext _context) : ICharacterRepo
{

  public Task<List<Dtos.CharacterDto>> GetCharacters()
  {
    return _context.Characters.Select(c => new Dtos.CharacterDto
    {
        Id = c.Id,
        Name = c.Name,
        Level = c.Level,
        Class = c.Class,
        Role = c.Role
    }).ToListAsync();
  }

  public async Task<Dtos.CharacterDto> GetCharacterById(int id)
  {
    var character = await _context.Characters.Where(c => c.Id == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Character with ID {id} not found.");
    return new Dtos.CharacterDto
    {
        Id = character.Id,
        Name = character.Name,
        Level = character.Level,
        Class = character.Class,
        Role = character.Role
    };
  }

  public async Task<Dtos.CharacterDto> CreateCharacter(Dtos.CharacterCreateDto characterCreateDto)
  {
    var character = new model.Character
    {
        Name = characterCreateDto.Name,
        Level = characterCreateDto.Level,
        Class = characterCreateDto.Class,
        Role = characterCreateDto.Role
    };

    _context.Characters.Add(character);
    await _context.SaveChangesAsync();
    return new Dtos.CharacterDto
    {
        Id = character.Id,
        Name = character.Name,
        Level = character.Level,
        Class = character.Class,
        Role = character.Role
    };
  }

  public async Task<Dtos.CharacterDto> UpdateCharacter(int id, Dtos.CharacterUpdateDto characterUpdateDto)
  {
    var character = await _context.Characters.FindAsync(id) ?? throw new KeyNotFoundException($"Character with ID {id} not found.");

    character.Name = characterUpdateDto.Name;
    character.Level = characterUpdateDto.Level;
    character.Class = characterUpdateDto.Class;
    character.Role = characterUpdateDto.Role;

    _context.Characters.Update(character);
    await _context.SaveChangesAsync();
    return new Dtos.CharacterDto
    {
        Id = character.Id,
        Name = character.Name,
        Level = character.Level,
        Class = character.Class,
        Role = character.Role
    };
  }

  public async Task<bool> DeleteCharacter(int id)
  {
    var character = await _context.Characters.FindAsync(id);
    if (character == null) return false;

    _context.Characters.Remove(character);
    await _context.SaveChangesAsync();
    return true;
  }
}

