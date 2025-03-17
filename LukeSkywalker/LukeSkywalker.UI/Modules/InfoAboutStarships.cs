using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace LukeSkywalker.UI.Modules;
public interface IInfoAboutStarships
{
    Task<List<StarshipDto>> GetInfo(List<string> starships);
}
public class InfoAboutStarships(IStarshipService starshipsService, ILogger<IInfoAboutStarships> logger) : IInfoAboutStarships
{
    public string GetTitle()
        => "Processing information about starships";

    public async Task<List<StarshipDto>> GetInfo(List<string> starships)
    {
        logger.LogInformation("Processing information about starships");
        List<int> ids = new List<int>();
        string pattern = @"(\d+)(?=\/$)";
        logger.LogDebug($"Input list of urls is: {string.Join('\n', starships)}");

        foreach (var url in starships)
        {
            var match = Regex.Match(url, pattern);
            if (match.Success)
            {
                logger.LogDebug($"Regex match success for: {url} \ngot value: {match.Value}");
                ids.Add(int.Parse(match.Value));
            }
        }
        var starchipInfo =  await starshipsService.GetInfoAboutStarships(ids);
        logger.LogInformation("Processing information about starships complete successfully");
        return starchipInfo;
    }
}
