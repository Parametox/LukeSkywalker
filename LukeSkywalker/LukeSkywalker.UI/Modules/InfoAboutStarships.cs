using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using System.Text.RegularExpressions;

namespace LukeSkywalker.UI.Modules;
public interface IInfoAboutStarships : IBaseModule
{
    Task<List<StarshipDto>> GetInfo(List<string> Starshipss);
}
public class InfoAboutStarships(IStarshipService starshipsService) : IInfoAboutStarships
{
    public string GetTitle()
        => "Processing information about starships";

    public async Task<List<StarshipDto>> GetInfo(List<string> starshipss)
    {
        List<int> ids = new List<int>();
        string pattern = @"(\d+)(?=\/$)";

        foreach (var url in starshipss)
        {
            var match = Regex.Match(url, pattern);
            if (match.Success)
            {
                ids.Add(int.Parse(match.Value));
            }
        }
        return await starshipsService.GetInfoAboutStarships(ids);
    }
}
