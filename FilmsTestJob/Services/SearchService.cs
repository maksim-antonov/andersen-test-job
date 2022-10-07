using FilmsTestJob.Contracts;
using FilmTestJob.Entities.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FilmsTestJob.Services;

public class SearchService : ISearchService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMemoryCache _cache;
    
    public SearchService(IRepositoryWrapper repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<SearchData> SearchAsync(string title)
    {
        if (!_cache.TryGetValue(title, out SearchData cacheValue))
        {
            if (string.IsNullOrWhiteSpace(title)) // not so clear return but why not
                return new SearchData()
                {
                    Expression = title,
                    ErrorMessage = "Please write something before request",
                    SearchType = "",
                    Results = new List<SearchResult>()
                };

            var data = await _repository.Search.GetFilmsByTitleAsync(title);
            
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));

            _cache.Set(title, data, cacheEntryOptions);

            return data;
        }

        return cacheValue;
    }
}