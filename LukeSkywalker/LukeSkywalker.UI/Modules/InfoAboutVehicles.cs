using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using System.Text.RegularExpressions;

namespace LukeSkywalker.UI.Modules;
public interface IInfoAboutVehicles : IBaseModule
{
    Task<List<VehicleDto>> GetInfo(List<string> vehicles);
}
public class InfoAboutVehicles(IVehicleService vehicleService) : IInfoAboutVehicles
{
    public string GetTitle()
        => "Processing information about movies";

    public async Task<List<VehicleDto>> GetInfo(List<string> vehicles)
    {
        List<int> ids = new List<int>();
        string pattern = @"(\d+)(?=\/$)";

        foreach (var url in vehicles)
        {
            var match = Regex.Match(url, pattern);
            if (match.Success)
            {
                ids.Add(int.Parse(match.Value));
            }
        }
        return await vehicleService.GetInfoAboutVehicles(ids);
    }
}
