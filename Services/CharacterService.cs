using Microsoft.EntityFrameworkCore;
using webApi.Repositories;
using webApi.Data;

namespace webApi.Services;

public class CharacterService(AppDbContext _context) : ICharacterRepo
{
  static readonly List<model.Character> characters =
          [
              new() { Id = 1, Name = "Aragon", Level = 20, Class = "Ranger", Game = "Lord of the Rings", Role = "Tank" },
            new() { Id = 2, Name = "Something", Level = 18, Class = "Archer", Game = "Lord of the Rings", Role = "DPS" },
            new() { Id = 3, Name = "Gandalf", Level = 25, Class = "Wizard", Game = "Lord of the Rings", Role = "Support" }
          ];
  public Task<List<Dtos.CharacterDto>> GetCharacters()
  {
    return _context.Characters.Select(c => new Dtos.CharacterDto
    {
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
        Name = character.Name,
        Level = character.Level,
        Class = character.Class,
        Role = character.Role
    };
  }

  public async Task<Dtos.CharacterDto> AddCharacter(model.Character character)
  {
    _context.Characters.Add(character);
    await _context.SaveChangesAsync();
    return new Dtos.CharacterDto
    {
        Name = character.Name,
        Level = character.Level,
        Class = character.Class,
        Role = character.Role
    };
  }

  public async Task<Dtos.CharacterDto> UpdateCharacter(model.Character character)
  {
    _context.Characters.Update(character);
    await _context.SaveChangesAsync();
    return new Dtos.CharacterDto
    {
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

