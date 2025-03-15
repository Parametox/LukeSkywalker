using LukeSkywalker.Core.Dtos;

namespace LukeSkywalker.Services.Abstractions;

public interface IMovieService
{
    Task<List<MovieDto>> GetInfoAboutMovies(List<int> ids);
}

