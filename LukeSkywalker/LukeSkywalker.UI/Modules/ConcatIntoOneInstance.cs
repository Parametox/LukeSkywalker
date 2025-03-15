using LukeSkywalker.Core;
using LukeSkywalker.Core.Dtos;

namespace LukeSkywalker.UI.Modules;

public interface IConcatIntoOneInstance : IBaseModule
{
    FinalLukeObject ConcatIntoOne(CharacterFullInfo characterFullInfo, List<MovieDto> movies, List<StarshipDto> starships, List<VehicleDto> vehicles);
}
public class ConcatIntoOneInstance : IConcatIntoOneInstance
{   
    public FinalLukeObject ConcatIntoOne(CharacterFullInfo characterFullInfo, List<MovieDto> movies, List<StarshipDto> starships, List<VehicleDto> vehicles)
    {
        return new FinalLukeObject()
        {
            Name = characterFullInfo.Name,
            Height = characterFullInfo.Height,
            Mass = characterFullInfo.Mass,
            HairColor = characterFullInfo.HairColor,
            SkinColor = characterFullInfo.SkinColor,
            EyeColor = characterFullInfo.EyeColor,
            BirthYear = characterFullInfo.BirthYear,
            Gender = characterFullInfo.Gender,
            Movies = movies,
            Starships = starships,
            Vehicles = vehicles
        };
    }

    public string GetTitle()
        => "Combining data";
}

