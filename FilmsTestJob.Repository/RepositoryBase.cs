using FilmsTestJob.Contracts;

namespace FilmsTestJob.Repository;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
}