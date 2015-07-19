namespace Problem5
{
    using System.Linq;

    public static class Concurrency
    {
        public static void Main()
        {
            var context1 = new SoftUniEntities();
            var context2 = new SoftUniEntities();

            context1.Employees.FirstOrDefault(e => e.LastName == "Nakov").FirstName = "Attempt1";
            context2.Employees.FirstOrDefault(e => e.LastName == "Nakov").FirstName = "Attemp2";

            context1.SaveChanges();
            context2.SaveChanges();
        }
    }
}
