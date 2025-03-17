using LukeSkywalker.Core.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LukeSkywalker.UI.Modules;
public interface ISaveToJson
{
    Task SaveFile(FinalLukeObject finalLukeObject);
}
public class SaveToJson(IConfiguration configuration, ILogger<ISaveToJson> logger) : ISaveToJson
{
    public async Task SaveFile(FinalLukeObject finalLukeObject)
    {
        logger.LogDebug("Starting serialization and saving to file");
        var jsonData = JsonConvert.SerializeObject(finalLukeObject, Formatting.Indented);
        var path = configuration["jsonDestinationPath"] ?? throw new ArgumentNullException("jsonDestinationPath");
        await File.WriteAllTextAsync(path, jsonData);
        logger.LogInformation("File saved");
    }
}

