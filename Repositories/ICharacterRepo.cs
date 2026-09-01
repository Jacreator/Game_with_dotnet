namespace webApi.Repositories;

public interface ICharacterRepo
{
    Task<List<Dtos.CharacterDto>> GetCharacters();

    Task<Dtos.CharacterDto> GetCharacterById(int id);

    Task<Dtos.CharacterDto> AddCharacter(model.Character character);

    Task<Dtos.CharacterDto> UpdateCharacter(model.Character character);

    Task<bool> DeleteCharacter(int id);
}
