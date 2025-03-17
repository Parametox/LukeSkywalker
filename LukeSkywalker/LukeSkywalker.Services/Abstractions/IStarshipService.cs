using LukeSkywalker.Core.Dtos;

namespace LukeSkywalker.Services.Abstractions;

public interface IStarshipService
{
    Task<List<StarshipDto>> GetInfoAboutStarships(List<int> ids);
}

