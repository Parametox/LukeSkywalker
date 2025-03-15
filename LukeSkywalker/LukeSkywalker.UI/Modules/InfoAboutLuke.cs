using LukeSkywalker.Core;
using LukeSkywalker.Services.Abstractions;

namespace LukeSkywalker.UI.Modules;

public interface IInfoAboutLuke: IBaseModule
{
    Task<CharacterFullInfo> GetInfo(int id);
}
public class InfoAboutLuke(ICharacterService characterService) : IInfoAboutLuke
{
    public string GetTitle() 
        => "Processing information about Luke Skywalker";

    public async Task<CharacterFullInfo> GetInfo(int id)
    {
        return await characterService.GetInfoByCharacter(id);
    }
  
}

