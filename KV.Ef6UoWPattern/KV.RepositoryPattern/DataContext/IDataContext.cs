using System;
using System.Data.Entity;

namespace KV.RepositoryPattern.DataContext
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void UpdateObjectState<TEntity>(TEntity entity, EntityState entityState) where TEntity : class;
    }
}