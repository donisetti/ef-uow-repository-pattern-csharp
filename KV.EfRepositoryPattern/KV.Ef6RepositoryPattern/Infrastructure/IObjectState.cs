
using System.ComponentModel.DataAnnotations.Schema;

namespace KV.Ef6RepositoryPattern.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}