using FilmsTestJob.Contracts;
using FilmsTestJob.Services;
using FilmTestJob.Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void TestMemoryCache()
        {
            // Arrange
            var inputTitle = "lord";
            var repositoryMock = new Mock<IRepositoryWrapper>();

            var data = new SearchData
            {
                Expression = "",
                ErrorMessage = "",
                SearchType = "Movies",
                Results = new List<SearchResult>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Description = "Apologize, Mr. Mario, beauty princess hides in other castle",
                        Image = "",
                        ResultType = "Title",
                        Title = "Super Mario Bros."
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Description = "Wake up, Neo",
                        Image = "",
                        ResultType = "Title",
                        Title = "Matrix"
                    }
                }
            };

            repositoryMock.Setup(m => m.Search.GetFilmsByTitleAsync(It.IsAny<string>())).ReturnsAsync(data);
            
            var cacheOptions = new MemoryCacheOptions();
            var cache = new MemoryCache(cacheOptions);
            var searchService = new SearchService(repositoryMock.Object, cache);

            // Act
            await searchService.SearchAsync(inputTitle);
            await searchService.SearchAsync(inputTitle);
            
            // Assert
            repositoryMock.Verify(x => x.Search.GetFilmsByTitleAsync(inputTitle), Times.Once());
        }
    }
}