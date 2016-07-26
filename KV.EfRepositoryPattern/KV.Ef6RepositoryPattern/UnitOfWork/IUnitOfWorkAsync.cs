using System.Threading;
using System.Threading.Tasks;
using KV.Ef6RepositoryPattern.Infrastructure;
using KV.Ef6RepositoryPattern.Repositories;

namespace KV.Ef6RepositoryPattern.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}