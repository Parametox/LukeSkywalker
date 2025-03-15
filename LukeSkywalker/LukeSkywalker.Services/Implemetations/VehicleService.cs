using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Integrations;
using LukeSkywalker.Services.Abstractions;

namespace LukeSkywalker.Services.Implemetations;

public class VehicleService : IVehicleService
{
    public async Task<List<VehicleDto>> GetInfoAboutVehicles(List<int> ids)
    {
        var retList = new List<VehicleDto>();
        RestApiInvoker restApiInvoker = new RestApiInvoker();

        foreach (var id in ids.Where(w => w > 0))
        {
            retList.Add(await restApiInvoker.GetAsync<VehicleDto?>($"vehicles/{id}/") ?? new VehicleDto());
        }

        return retList;
    }
}

