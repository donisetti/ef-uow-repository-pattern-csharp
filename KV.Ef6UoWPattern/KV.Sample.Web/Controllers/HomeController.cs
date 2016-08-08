using KV.Sample.Domain;
using KV.Sample.Service.Interfaces;
using System.Web.Mvc;

namespace KV.Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courseService;

        public HomeController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public ActionResult Index()
        {
            Teacher teacher = new Teacher();
            teacher.Name = "Professor Três";

            Teacher teacher2 = new Teacher();
            teacher2.Name = "Professor Quatro";

            Course course1 = new Course();
            course1.Number = "Curso da vida";
            course1.Description = "Aprender um poquinho que a vida não é um toddynho";
            course1.TeacherList.Add(teacher);
            course1.TeacherList.Add(teacher2);

            courseService.Insert(course1);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}