using KV.Ef6RepositoryPattern.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace KV.Ef6RepositoryPattern.Entity
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
