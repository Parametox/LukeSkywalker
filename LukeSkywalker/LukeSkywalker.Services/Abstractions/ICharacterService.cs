using LukeSkywalker.Core;

namespace LukeSkywalker.Services.Abstractions;

public interface ICharacterService
{
    Task<CharacterFullInfo> GetInfoByCharacter(int id);
}

