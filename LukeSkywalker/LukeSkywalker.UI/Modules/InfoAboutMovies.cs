using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using System.Text.RegularExpressions;

namespace LukeSkywalker.UI.Modules;

public interface IInfoAboutMovies : IBaseModule
{
    Task<List<MovieDto>> GetInfo(List<string> films);
}
public class InfoAboutMovies(IMovieService movieService) : IInfoAboutMovies
{
    public string GetTitle() 
        => "Processing information about movies";

    public async Task<List<MovieDto>> GetInfo(List<string> films)
    {
        List<int> ids = new List<int>();
        string pattern = @"(\d+)(?=\/$)";

        foreach (var url in films)
        {
            var match = Regex.Match(url, pattern);
            if (match.Success)
            {
                ids.Add(int.Parse(match.Value));
            }
        }
        return await movieService.GetInfoAboutMovies(ids);
    }
}

