using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace LukeSkywalker.UI.Modules;
public interface IInfoAboutVehicles
{
    Task<List<VehicleDto>> GetInfo(List<string> vehicles);
}
public class InfoAboutVehicles(IVehicleService vehicleService, ILogger<IInfoAboutVehicles> logger) : IInfoAboutVehicles
{   
    public async Task<List<VehicleDto>> GetInfo(List<string> vehicles)
    {
        logger.LogInformation("Processing information about vehicles");
        List<int> ids = new List<int>();
        string pattern = @"(\d+)(?=\/$)";
        logger.LogDebug($"Input list of urls is: {string.Join('\n',vehicles)}");
        foreach (var url in vehicles)
        {
            var match = Regex.Match(url, pattern);
            if (match.Success)
            {
                logger.LogDebug($"Regex match success for: {url} \ngot value: {match.Value}");
                ids.Add(int.Parse(match.Value));
            }
        }
        var vehicleInfo = await vehicleService.GetInfoAboutVehicles(ids);
        logger.LogInformation("Processing information about vehicles complete successfully");

        return vehicleInfo;
    }
}
