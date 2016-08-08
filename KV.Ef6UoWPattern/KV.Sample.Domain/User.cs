using KV.RepositoryPattern.Entity;
using System;

namespace KV.Sample.Domain
{
    public class User : Entity
    {
        public Guid UserId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}