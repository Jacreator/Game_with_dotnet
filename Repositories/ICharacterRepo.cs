namespace webApi.Repositories;

public interface ICharacterRepo
{
    Task<List<Dtos.CharacterDto>> GetCharacters();

    Task<Dtos.CharacterDto> GetCharacterById(int id);

    Task<Dtos.CharacterDto> CreateCharacter(Dtos.CharacterCreateDto characterCreateDto);

    Task<Dtos.CharacterDto> UpdateCharacter(int id, Dtos.CharacterUpdateDto characterUpdateDto);

    Task<bool> DeleteCharacter(int id);
}
