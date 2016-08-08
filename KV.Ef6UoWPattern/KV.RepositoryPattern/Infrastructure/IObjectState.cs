using System.ComponentModel.DataAnnotations.Schema;

namespace KV.RepositoryPattern.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}