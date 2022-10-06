using FilmsTestJob.Contracts;
using FilmsTestJob.Contracts.Services;
using FilmsTestJob.Repository.Services;

namespace FilmsTestJob.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private ISearchRepository _searchRepository;

    public ISearchRepository Search
    {
        get
        {
            if (_searchRepository == null)
                _searchRepository = new SearchRepository();
            return _searchRepository;
        }
    }
}