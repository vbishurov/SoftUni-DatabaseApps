namespace Transactions.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class TransactionsContext : DbContext
    {
        public TransactionsContext()
            : base("TransactionsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TransactionsContext, Configuration>());
        }

        public virtual DbSet<News> News { get; set; }
    }
}