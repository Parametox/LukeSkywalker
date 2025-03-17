using LukeSkywalker.Core;
using LukeSkywalker.Core.Dtos;
using Microsoft.Extensions.Logging;

namespace LukeSkywalker.UI.Modules;

public interface IConcatIntoOneInstance
{
    FinalLukeObject ConcatIntoOne(CharacterFullInfo characterFullInfo, List<MovieDto> movies, List<StarshipDto> starships, List<VehicleDto> vehicles);
}
public class ConcatIntoOneInstance(ILogger<IConcatIntoOneInstance> logger) : IConcatIntoOneInstance
{   
    public FinalLukeObject ConcatIntoOne(CharacterFullInfo characterFullInfo, List<MovieDto> movies, List<StarshipDto> starships, List<VehicleDto> vehicles)
    {
        logger.LogInformation("Combining data");
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
}

