using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace LukeSkywalker.UI.Modules;

public interface IInfoAboutMovies
{
    Task<List<MovieDto>> GetInfo(List<string> films);
}
public class InfoAboutMovies(IMovieService movieService, ILogger<IInfoAboutMovies> logger) : IInfoAboutMovies
{
    public string GetTitle() 
        => "Processing information about movies";

    public async Task<List<MovieDto>> GetInfo(List<string> films)
    {
        logger.LogInformation("Processing information about movies");
        List<int> ids = new List<int>();
        string pattern = @"(\d+)(?=\/$)";
        logger.LogDebug($"Input list of urls is: {string.Join('\n', films)}");

        foreach (var url in films)
        {
            var match = Regex.Match(url, pattern);
            if (match.Success)
            {
                logger.LogDebug($"Regex match success for: {url} \ngot value: {match.Value}");
                ids.Add(int.Parse(match.Value));
            }
        }
        var moviesInfo = await movieService.GetInfoAboutMovies(ids);
        logger.LogInformation("Processing information about movies complete successfully");

        return moviesInfo;
    }
}

