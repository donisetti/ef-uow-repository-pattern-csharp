using Autofac;
using Autofac.Integration.Mvc;
using KV.Sample.Repository;
using KV.Sample.Service;
using System.Web.Mvc;

namespace KV.Sample.Web.App_Start
{
    public class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.RegisterModule<RepositoryAutoFacModule>();
            builder.RegisterModule<ServiceAutoFacModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}