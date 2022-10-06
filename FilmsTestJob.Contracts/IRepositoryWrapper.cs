using FilmsTestJob.Contracts.Services;

namespace FilmsTestJob.Contracts;

public interface IRepositoryWrapper
{
    ISearchRepository Search { get; }
}