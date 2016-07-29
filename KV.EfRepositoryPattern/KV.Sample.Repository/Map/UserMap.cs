using KV.Sample.Domain;
using System.Data.Entity.ModelConfiguration;

namespace KV.Sample.Repository.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.UserId);
            Property(x => x.Mail).IsRequired().HasMaxLength(150);
            Property(u => u.Password).HasMaxLength(20).IsRequired();
        }
    }
}