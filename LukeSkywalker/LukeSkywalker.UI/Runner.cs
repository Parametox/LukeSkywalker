using LukeSkywalker.UI.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LukeSkywalker.UI;

public interface IRunner
{
    Task Run(int id);
}

public class Runner : IRunner
{
    private readonly ILogger<Runner> _logger;
    private readonly IServiceProvider _configuration;

    public Runner(ILogger<Runner> logger, IServiceProvider configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task Run(int id)
    {
        _logger.LogInformation($"Runner started for id: {id}");

        var infoAboutLuke = _configuration.GetService<IInfoAboutLuke>();
        var infoAboutMovies = _configuration.GetService<IInfoAboutMovies>();
        var infoAboutVehicles = _configuration.GetService<IInfoAboutVehicles>();
        var infoAboutStarships = _configuration.GetService<IInfoAboutStarships>();
        var concatIntoOneInstance  = _configuration.GetService<IConcatIntoOneInstance>();
        var saveToJson = _configuration.GetService<ISaveToJson>();

        var fullInfo = await infoAboutLuke!.GetInfo(id);      

        var movies = await infoAboutMovies!.GetInfo(fullInfo.Films);
        var vehicles = await infoAboutVehicles!.GetInfo(fullInfo.Vehicles);
        var starships = await infoAboutStarships!.GetInfo(fullInfo.Starships);
        var final = concatIntoOneInstance!.ConcatIntoOne(fullInfo, movies, starships, vehicles);

        await saveToJson!.SaveFile(final);

        _logger.LogInformation($"Runner complete successfully for id: {id}");
    }
}
