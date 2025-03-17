using LukeSkywalker.Core;
using LukeSkywalker.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace LukeSkywalker.UI.Modules;

public interface IInfoAboutLuke
{
    Task<CharacterFullInfo> GetInfo(int id);
}
public class InfoAboutLuke(ICharacterService characterService, ILogger<IInfoAboutLuke> logger) : IInfoAboutLuke
{    
    public async Task<CharacterFullInfo> GetInfo(int id)
    {
        logger.LogInformation("Processing information about Luke Skywalker");
        var charInfo = await characterService.GetInfoByCharacter(id);
        logger.LogInformation("Processing information about Luke Skywalker complete successfully");

        return charInfo;
    }  
}

