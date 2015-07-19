namespace Problem6
{
    using System;

    public static class StoredProcedure
    {
        public static void Main()
        {
            var context = new SoftUniEntities();

            var test = context.GetProjectsByEmployee("Ruth", "Ellerbrock");
            foreach (var project in test)
            {
                Console.WriteLine("{0} - {1} , {2}", project.name, project.Description.Length <= 30 ? project.Description : project.Description.Substring(0, 30) + "...", project.StartDate.ToLocalTime().ToString("g"));
            }
        }
    }
}
