using System.Threading;
using System.Threading.Tasks;
using KV.RepositoryPattern.Infrastructure;
using KV.RepositoryPattern.Repositories;

namespace KV.RepositoryPattern.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}