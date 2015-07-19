namespace StudentSystem.Data
{
    using System;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }

        public virtual  DbSet<Models.License> Licenses { get; set; }
    }
}