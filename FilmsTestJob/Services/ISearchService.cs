using FilmTestJob.Entities.Models;

namespace FilmsTestJob.Services;

public interface ISearchService
{
    Task<SearchData> SearchAsync(string title);
}