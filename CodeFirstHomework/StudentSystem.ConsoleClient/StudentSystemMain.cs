namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using Data;

    public static class StudentSystemMain
    {
        public static void Main()
        {
            var context = new StudentSystemContext();

            // Problem 3

            // Task 1

            var studentsHomeworks = context.Students.Select(s => new
            {
                s.Name,
                Homeworks = s.Homeworks.Select(h => new
                {
                    h.Content,
                    h.ContentType
                }).ToList()
            });

            //foreach (var student in studentsHomeworks)
            //{
            //    Console.WriteLine("{0} - Homeworks: {1}", student.Name, student.Homeworks.Count());
            //}

            // Task 2

            var courseResources = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                });

            // Task 3

            var courseOver5Resources = context.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenBy(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    ResourceCount = c.Resources.Count
                });

            // Task 4

            var activeCourse = context.Courses
                .Where(c => c.StartDate < DateTime.Now && c.EndDate > DateTime.Now)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = DbFunctions.DiffDays(c.EndDate, c.StartDate),
                    EnrolledStudents = c.Students.Count
                })
                .OrderByDescending(c => c.EnrolledStudents)
                .ThenByDescending(c => c.Duration);

            //foreach (var course in activeCourse)
            //{
            //    Console.WriteLine("{0} {1} {2} {3} {4}", course.Name, course.StartDate, course.EndDate, course.Duration, course.EnrolledStudents);
            //}

            // Task 5

            var studentsCourses = context.Students.Select(s => new
            {
                s.Name,
                NumberOfCOurses = s.Courses.Count,
                TotalPrice = s.Courses.Sum(c => c.Price),
                AveragePrice = s.Courses.Average(c => c.Price)
            })
            .OrderByDescending(s => s.TotalPrice)
            .ThenByDescending(s => s.NumberOfCOurses)
            .ThenBy(s => s.Name);
        }
    }
}
