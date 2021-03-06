namespace KV.Sample.Repository.Migrations
{
    using Domain;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            Teacher teacher = new Teacher();
            teacher.Name = "Professor Um";

            Teacher teacher2 = new Teacher();
            teacher2.Name = "Professor Dois";

            Course course1 = new Course();
            course1.Number = "70-480";
            course1.Description = "Programming in HTML5 with JavaScript and CSS3";
            course1.TeacherList.Add(teacher);
            course1.TeacherList.Add(teacher2);

            Course course2 = new Course();
            course2.Number = "70-486";
            course2.Description = "Developing ASP.NET MVC 4 Web Applications";
            course2.TeacherList.Add(teacher2);

            context.Courses.Add(course1);
            context.Courses.Add(course2);
        }
    }
}