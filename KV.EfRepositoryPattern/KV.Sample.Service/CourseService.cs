using KV.Sample.Domain;
using KV.Sample.Service.Interfaces;
using KV.ServicePattern;
using KV.RepositoryPattern.Repositories;

namespace KV.Sample.Service
{
    public class CourseService : Service<Course>, ICourseService
    {
        public CourseService(IRepositoryAsync<Course> repository) : base(repository)
        {
        }
    }
}