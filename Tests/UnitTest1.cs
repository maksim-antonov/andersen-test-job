using FilmsTestJob.Repository;
using FilmsTestJob.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void TestMemoryCache()
        {
            // Arrange
            var rWrapper = new RepositoryWrapper();
            var cacheOptions = new MemoryCacheOptions();
            var cache = new MemoryCache(cacheOptions);
            var searchService = new SearchService(rWrapper, cache);
            var inputTitle = "lord";
            
            // Act
            var resultFromFirstCall = await searchService.SearchAsync(inputTitle);
            var resultFromSecondCall = await searchService.SearchAsync(inputTitle);
            
            // Assert
            Assert.Same(resultFromFirstCall, resultFromSecondCall); // I think this test is not so clear, but Idk how to test it differently
        }

        [Fact]
        public async void TestEmptyInput()
        {
            // Arrange
            var rWrapper = new RepositoryWrapper();
            var cacheOptions = new MemoryCacheOptions();
            var cache = new MemoryCache(cacheOptions);
            var searchService = new SearchService(rWrapper, cache);
            var inputTitle = "";
            
            // Act
            var result = await searchService.SearchAsync(inputTitle);
            
            // Assert
            
            // Assert.True(!result.Results.Any());
            // Assert.False(result.Results.Any());
            Assert.Empty(result.Results);
            Assert.False(string.IsNullOrWhiteSpace(result.ErrorMessage));
        }

        [Fact]
        public async void TestGoodInput()
        {
            // Arrange
            var rWrapper = new RepositoryWrapper();
            var cacheOptions = new MemoryCacheOptions();
            var cache = new MemoryCache(cacheOptions);
            var searchService = new SearchService(rWrapper, cache);
            var inputTitle = "reload";
            var searchType = "Movies";
            
            // Act
            var result = await searchService.SearchAsync(inputTitle);
            
            // Assert
            Assert.True(string.IsNullOrWhiteSpace(result.ErrorMessage));
            Assert.Contains(result.SearchType, searchType);
            Assert.Contains(result.Expression, inputTitle);
            Assert.NotEmpty(result.Results);
        }
    }
}