using KV.RepositoryPattern.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace KV.RepositoryPattern.Entity
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
