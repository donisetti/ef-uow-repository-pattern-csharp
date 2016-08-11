using KV.Sample.Domain;
using KV.Sample.Service.Interfaces;
using System;
using System.Web.Mvc;
using System.Linq;

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
            //Teacher teacher = new Teacher();
            //teacher.Name = "Professor Três";

            //Teacher teacher2 = new Teacher();
            //teacher2.Name = "Professor Quatro";

            //Course course1 = new Course();
            //course1.Number = "Curso da vida 3";
            //course1.Description = "Aprender um poquinho que a vida não é um toddynho, não é mesmo!";
            //course1.TeacherList.Add(teacher);
            //course1.TeacherList.Add(teacher2);

            //courseService.Insert(course1);

            //courseService.Delete(new Guid("f6dac3c7-6b5f-e611-bc1e-18037364e507"));

            var course = courseService.Query(x => x.Description == "Programming in HTML5 with JavaScript and CSS3").Select().FirstOrDefault();

            course.Description = "TESTE UPDATE";

            courseService.Update(course);

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