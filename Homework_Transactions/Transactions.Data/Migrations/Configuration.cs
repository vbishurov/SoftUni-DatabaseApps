namespace Transactions.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TransactionsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TransactionsContext context)
        {
            if (context.News.Any())
            {
                return;
            }

            var newsItem = new News()
            {
                Content = "newsItemContent"
            };

            context.News.Add(newsItem);

            context.SaveChanges();
        }
    }
}
