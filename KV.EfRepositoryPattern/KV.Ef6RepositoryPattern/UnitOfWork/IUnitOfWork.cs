using System;
using System.Data;
using KV.Ef6RepositoryPattern.Infrastructure;
using KV.Ef6RepositoryPattern.Repositories;

namespace KV.Ef6RepositoryPattern.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}