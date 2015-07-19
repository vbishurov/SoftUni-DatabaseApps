namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;

    public static class Homework
    {
        public static void Main()
        {
            // Problem 3
            var context = new SoftUniEntities();

            // Task 1

            var employees = context.Employees
                .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Manager = context.Employees.Where(m => m.EmployeeID == e.ManagerID).Select(m => m.FirstName + " " + m.LastName).FirstOrDefault(),
                    Projects = e.Projects.Select(p => new
                    {
                        p.Name,
                        p.StartDate,
                        p.EndDate
                    })
                });

            // Task 2

            var addresses =
                context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name).Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    Town = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                });

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees", address.AddressText, address.Town, address.EmployeeCount);
            }

            // Task 3

            var employee = context.Employees.Where(e => e.EmployeeID == 147).Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.Projects.OrderByDescending(p => p.Name).Select(p => p.Name)
            }).FirstOrDefault();

            Console.WriteLine("{0} {1} ({2}) - {3}", employee.FirstName, employee.LastName, employee.JobTitle, string.Join(", ", employee.Projects));

            // Task 4

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    d.Name,
                    Manager = context.Employees.Where(m => m.EmployeeID == d.ManagerID).Select(m => m.FirstName + " " + m.LastName).FirstOrDefault(),
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.HireDate,
                        e.JobTitle
                    })
                });

            foreach (var department in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}", department.Name, department.Manager, department.Employees.Count());
            }
        }
    }
}
