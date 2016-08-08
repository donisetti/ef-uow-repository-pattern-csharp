using Autofac;
using KV.RepositoryPattern.DataContext;
using KV.RepositoryPattern.Repositories;
using KV.RepositoryPattern.UnitOfWork;
using KV.Sample.Domain;

namespace KV.Sample.Repository
{
    public class RepositoryAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().As<IDataContextAsync>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerRequest();
            builder.RegisterType<Repository<Course>>().As<IRepositoryAsync<Course>>();            
        }
    }
}