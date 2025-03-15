using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Integrations;
using LukeSkywalker.Services.Abstractions;

namespace LukeSkywalker.Services.Implemetations;

public class StarshipService : IStarshipService
{
    public async Task<List<StarshipDto>> GetInfoAboutStarships(List<int> ids)
    {
        var retList = new List<StarshipDto>();
        RestApiInvoker restApiInvoker = new RestApiInvoker();

        foreach (var id in ids.Where(w => w > 0))
        {
            retList.Add(await restApiInvoker.GetAsync<StarshipDto?>($"starships/{id}/") ?? new StarshipDto());
        }

        return retList;
    }
}

