namespace webApi.Dtos;


public class CharacterDto
{
    public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
  public string Class { get; set; } = string.Empty;
  public string Role { get; set; } = string.Empty;
}

public class CharacterCreateDto
{
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public string Class { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}

public class CharacterUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public string Class { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}