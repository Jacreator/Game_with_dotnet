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
  public Task<List<model.Character>> GetCharacters()
  {
    return _context.Characters.ToListAsync();
  }

  public async Task<model.Character> GetCharacterById(int id)
  {
    var character = await _context.Characters.FindAsync(id) ?? throw new KeyNotFoundException($"Character with ID {id} not found.");
    return character;
  }

  public async Task<model.Character> AddCharacter(model.Character character)
  {
    _context.Characters.Add(character);
    await _context.SaveChangesAsync();
    return character;
  }

  public async Task<model.Character> UpdateCharacter(model.Character character)
  {
    _context.Characters.Update(character);
    await _context.SaveChangesAsync();
    return character;
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

