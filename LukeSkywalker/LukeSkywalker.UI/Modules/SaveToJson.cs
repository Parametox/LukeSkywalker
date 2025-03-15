using LukeSkywalker.Core.Dtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LukeSkywalker.UI.Modules;
public interface ISaveToJson
{
    Task SaveFile(FinalLukeObject finalLukeObject);
}
public class SaveToJson(IConfiguration configuration) : ISaveToJson
{
    public async Task SaveFile(FinalLukeObject finalLukeObject)
    {
        var jsonData = JsonConvert.SerializeObject(finalLukeObject, Formatting.Indented);
        var path = configuration["jsonDestinationPath"] ?? throw new ArgumentNullException("jsonDestinationPath");
        await File.WriteAllTextAsync(path, jsonData);

        await Task.Delay(100);
    }
}

