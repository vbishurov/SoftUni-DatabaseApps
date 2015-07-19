namespace Problem4
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using SoftUni;

    public static class NativeSQL
    {
        public static void Main()
        {
            var context = new SoftUniEntities();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var framework =
                context.Employees.Where(e => e.Projects.Count(p => p.StartDate.Year == 2002) > 0)
                    .Select(e => e.FirstName).ToList();
            stopwatch.Stop();

            Console.WriteLine("Linq: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();

            stopwatch.Start();
            var native =
                context.Database.SqlQuery<string>(
                    "select e.FirstName from Employees e inner JOIN EmployeesProjects ep on e.EmployeeID = ep.EmployeeID inner join Projects p on ep.ProjectID = p.ProjectID where year(p.StartDate) = 2002")
                    .ToList();
            stopwatch.Stop();

            Console.WriteLine("Native: {0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
