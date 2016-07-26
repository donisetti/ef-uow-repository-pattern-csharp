using System.Threading;
using System.Threading.Tasks;

namespace KV.Ef6RepositoryPattern.DataContext
{
    public interface IDataContextAsync : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }
}