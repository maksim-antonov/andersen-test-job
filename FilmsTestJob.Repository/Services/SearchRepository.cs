using FilmsTestJob.Contracts.Services;
using FilmsTestJob.Repository.AppContext;
using FilmTestJob.Entities.Models;
using Newtonsoft.Json;

namespace FilmsTestJob.Repository.Services;

public class SearchRepository : RepositoryBase<SearchResult>, ISearchRepository
{
    public async Task<SearchData> GetFilmsByTitleAsync(string title)
    {
        string json = await ApplicationContext.Http.GetStringAsync($"https://imdb-api.com/en/API/SearchMovie/k_bnl5h3cz/{title}");

        SearchData data = JsonConvert.DeserializeObject<SearchData>(json);

        return data;
    }
}