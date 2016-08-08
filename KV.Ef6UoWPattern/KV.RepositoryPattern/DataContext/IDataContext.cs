using System;

namespace KV.RepositoryPattern.DataContext
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
    }
}