using System;
using KV.Ef6RepositoryPattern.Infrastructure;

namespace KV.Ef6RepositoryPattern.DataContext
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
        void SyncObjectsStatePostCommit();
    }
}