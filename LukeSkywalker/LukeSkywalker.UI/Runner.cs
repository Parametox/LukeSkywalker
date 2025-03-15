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
    /*
     Odpyta API: http://swapi.dev/api/people/1/
    Pobierze nazwy wszystkich filmów,
    pojazdów i
    statków, na których się znajdował
     
    Obiekt proszę zapisać w formacie json do pliku txt
    Logowanie
     */
    private readonly ILogger<Runner> _logger;
    private readonly IServiceProvider _configuration;

    public Runner(ILogger<Runner> logger, IServiceProvider configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task Run(int id)
    {
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
    }
}
