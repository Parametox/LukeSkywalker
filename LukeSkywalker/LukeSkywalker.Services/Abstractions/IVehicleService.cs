using LukeSkywalker.Core.Dtos;

namespace LukeSkywalker.Services.Abstractions;

public interface IVehicleService
{
    Task<List<VehicleDto>> GetInfoAboutVehicles(List<int> ids);

}

