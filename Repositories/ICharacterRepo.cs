namespace webApi.Repositories;

public interface ICharacterRepo
{
    Task<List<model.Character>> GetCharacters();

    Task<model.Character> GetCharacterById(int id);

    Task<model.Character> AddCharacter(model.Character character);

    Task<model.Character> UpdateCharacter(model.Character character);

    Task<bool> DeleteCharacter(int id);
}
