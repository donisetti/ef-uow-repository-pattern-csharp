using Autofac;
using KV.Sample.Service.Interfaces;

namespace KV.Sample.Service
{
    public class ServiceAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseService>().As<ICourseService>();
        }
    }
}