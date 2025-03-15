namespace LukeSkywalker.Core.Dtos;

public class FinalLukeObject
{
    public string Name { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string HairColor { get; set; }
    public string SkinColor { get; set; }
    public string EyeColor { get; set; }
    public string BirthYear { get; set; }
    public string Gender { get; set; }

    public List<MovieDto> Movies { get; set; }
    public List<StarshipDto> Starships { get; set; }
    public List<VehicleDto> Vehicles { get; set; }
}

