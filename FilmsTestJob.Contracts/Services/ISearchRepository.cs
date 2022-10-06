using FilmTestJob.Entities.Models;

namespace FilmsTestJob.Contracts.Services;

public interface ISearchRepository : IRepositoryBase<SearchData>
{
    Task<SearchData> GetFilmsByTitleAsync(string title);
}