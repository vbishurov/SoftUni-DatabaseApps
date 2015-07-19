namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystem.Data.StudentSystemContext";
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            if (context.Courses.Any() || context.HomeworkSubmissions.Any() || context.Students.Any() || context.Resources.Any())
            {
                return;
            }

            var random = new Random();

            var student = new Student();
            for (int i = 0; i < 100; i++)
            {
                student = new Student()
                {
                    Name = "Student" + i,
                    RegistrationDate = DateTime.Now.AddHours(random.Next(-10000, 10000))
                };

                context.Students.Add(student);
            }

            context.SaveChanges();

            var course = new Course();

            for (int i = 1; i < 200; i++)
            {
                course = new Course()
                {
                    StartDate = DateTime.Now.AddHours(random.Next(-2000, -10)),
                    EndDate = DateTime.Now.AddHours(random.Next(10, 2000)),
                    Name = "Course" + i,
                    Price = random.Next(20, 1000),
                    Students = context.Students.Where(s => s.Id % i == 0).ToList()
                };

                context.Courses.Add(course);

            }

            context.SaveChanges();

            var resource = new Resource();
            var resourceTypeValues = Enum.GetValues(typeof(ResourceType));

            for (int i = 0; i < 500; i++)
            {
                var courseId = random.Next(1, 200);

                resource = new Resource()
                {
                    Name = "Resource" + i,
                    URL = "http://localhost:" + random.Next(0, 60000) + "/Resource" + i,
                    ResourceType = (ResourceType)resourceTypeValues.GetValue(random.Next(resourceTypeValues.Length)),
                    Course = context.Courses.FirstOrDefault(c => c.Id == courseId)
                };

                context.Resources.Add(resource);
            }

            context.SaveChanges();

            var resources = context.Resources.ToList();

            for (int i = 1; i < resources.Count(); i++)
            {
                if (context.Courses.Any(r => r.Id % i == 0))
                {
                    resources[i].Course = context.Courses.FirstOrDefault(r => r.Id % i == 0);
                }
                else
                {
                    var id = random.Next(1, 200);
                    resources[i].Course = context.Courses.FirstOrDefault(c => c.Id == id);
                }
            }

            context.SaveChanges();

            var homework = new Homework();
            var contentTypeValues = Enum.GetValues(typeof(ContentType));

            for (int i = 0; i < 300; i++)
            {
                var studentId = random.Next(1, 100);
                var courseId = random.Next(1, 200);

                homework = new Homework()
                {
                    Content = "HomeworkSubmission" + i,
                    ContentType = (ContentType)contentTypeValues.GetValue(random.Next(contentTypeValues.Length)),
                    Student = context.Students.FirstOrDefault(s => s.Id == studentId),
                    SubmissionDate = DateTime.Now.AddHours(random.Next(-2500, 2500)),
                    Course = context.Courses.FirstOrDefault(c => c.Id == courseId)
                };

                context.HomeworkSubmissions.Add(homework);
            }

            context.SaveChanges();
        }
    }
}
