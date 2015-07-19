namespace SoftUni
{
    using System.Data.Entity;

    public static class DataAccessEmployee
    {
        public static void Add(Employee employee)
        {
            var context = new SoftUniEntities();

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            var context = new SoftUniEntities();

            return context.Employees.Find(key);
        }

        public static void Modify(Employee employee)
        {
            var context = new SoftUniEntities();

            context.Employees.Attach(employee);
            context.Entry(employee).State = EntityState.Modified;

            context.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            var context = new SoftUniEntities();

            context.Employees.Remove(employee);

            context.SaveChanges();
        }
    }
}
