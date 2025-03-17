using LukeSkywalker.Services.Abstractions;
using LukeSkywalker.Services.Implemetations;
using LukeSkywalker.UI.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace LukeSkywalker.UI.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRunner, Runner>();

        serviceCollection.AddScoped<IVehicleService, VehicleService>();
        serviceCollection.AddScoped<IStarshipService, StarshipService>();
        serviceCollection.AddScoped<IMovieService, MovieService>();
        serviceCollection.AddScoped<ICharacterService, CharacterService>();

        serviceCollection.AddScoped<IInfoAboutLuke, InfoAboutLuke>();
        serviceCollection.AddScoped<IInfoAboutMovies, InfoAboutMovies>();
        serviceCollection.AddScoped<IInfoAboutVehicles, InfoAboutVehicles>();
        serviceCollection.AddScoped<IInfoAboutStarships, InfoAboutStarships>();
        serviceCollection.AddScoped<IConcatIntoOneInstance, ConcatIntoOneInstance>();
        serviceCollection.AddScoped<ISaveToJson, SaveToJson>();
                
        return serviceCollection;
    }
}

