using LukeSkywalker.Core;
using LukeSkywalker.Integrations;
using LukeSkywalker.Services.Abstractions;

namespace LukeSkywalker.Services.Implemetations;

public class CharacterService : ICharacterService
{
    public async Task<CharacterFullInfo> GetInfoByCharacter(int id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        RestApiInvoker restApiInvoker = new RestApiInvoker();
        return await restApiInvoker.GetAsync<CharacterFullInfo?>($"people/{id}/") ?? new CharacterFullInfo();
    }
}

