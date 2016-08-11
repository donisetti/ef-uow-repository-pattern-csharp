using KV.RepositoryPattern.DataContext;
using KV.RepositoryPattern.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using System.Data.Entity.Infrastructure;

namespace KV.RepositoryPattern.UnitOfWork
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        #region Private Fields

        private IDataContextAsync dataContext;
        private bool disposed;
        private ObjectContext objectContext;
        private DbTransaction transaction;
        private Dictionary<string, dynamic> repositories;

        #endregion Private Fields

        #region Constuctor/Dispose

        public UnitOfWork(IDataContextAsync dataContext)
        {
            this.dataContext = dataContext;
            repositories = new Dictionary<string, dynamic>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only

                try
                {
                    if (objectContext != null && objectContext.Connection.State == ConnectionState.Open)
                    {
                        objectContext.Connection.Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                    // do nothing, the objectContext has already been disposed
                }

                if (dataContext != null)
                {
                    dataContext.Dispose();
                    dataContext = null;
                }
            }

            // release any unmanaged objects
            // set the object references to null

            disposed = true;
        }

        #endregion Constuctor/Dispose

        public int SaveChanges()
        {
            return dataContext.SaveChanges();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IRepository<TEntity>>();
            }

            return RepositoryAsync<TEntity>();
        }

        public Task<int> SaveChangesAsync()
        {
            return dataContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return dataContext.SaveChangesAsync(cancellationToken);
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IRepositoryAsync<TEntity>>();
            }

            if (repositories == null)
            {
                repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;

            if (repositories.ContainsKey(type))
            {
                return (IRepositoryAsync<TEntity>)repositories[type];
            }

            var repositoryType = typeof(Repository<>);

            repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), dataContext, this));

            return repositories[type];
        }

        #region Unit of Work Transactions

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            objectContext = ((IObjectContextAdapter)dataContext).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }

            transaction = objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            transaction.Rollback();            
        }

        #endregion
    }
}
