namespace EntityFrameworkExercise
{
    using System;
    using System.Linq;

    public static class Exercieses
    {
        public static void Main()
        {
            var context = new SoftUniEntities();

            // Task 1

            //var employees = context.Employees
            //    .Where(e => e.Salary > 50000)
            //    .Select(e => e.FirstName);

            //foreach (string employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}

            // Task 2

            //var employees = context.Employees
            //    .Where(e => e.Department.Name == "Research and Development")
            //    .OrderBy(e => e.Salary)
            //    .ThenByDescending(e => e.FirstName)
            //    .Select(e => new
            //    {
            //        e.FirstName,
            //        e.LastName,
            //        Department = e.Department.Name,
            //        e.Salary
            //    });

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} {1} from {2} - ${3:F2}", employee.FirstName, employee.LastName, employee.Department, employee.Salary);
            //}

            // Task 3

            //var address = new Address()
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            //employee.Address = address;

            //context.SaveChanges();

            //Console.WriteLine(employee.Address.AddressText);
        }
    }
}
