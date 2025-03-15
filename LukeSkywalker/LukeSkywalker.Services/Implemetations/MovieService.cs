using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Integrations;
using LukeSkywalker.Services.Abstractions;

namespace LukeSkywalker.Services.Implemetations;

public class MovieService : IMovieService
{
    public async Task<List<MovieDto>> GetInfoAboutMovies(List<int> ids)
    {
        var retList = new List<MovieDto>();
        RestApiInvoker restApiInvoker = new RestApiInvoker();

        foreach (var id in ids.Where(w => w > 0))
        {
            retList.Add(await restApiInvoker.GetAsync<MovieDto?>($"films/{id}/") ?? new MovieDto());
        }

        return retList;
    }
}

