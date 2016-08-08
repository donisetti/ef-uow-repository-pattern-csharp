using KV.Sample.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KV.Sample.Repository.Map
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            ToTable("Teacher");

            //Id gerado na aplicação através do Guid
            Property(x => x.TeacherId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}