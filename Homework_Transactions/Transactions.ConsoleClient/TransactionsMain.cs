namespace Transactions.ConsoleClient
{
    using System.Linq;
    using Data;

    public static class TransactionsMain
    {
        public static void Main()
        {
            var context = new TransactionsContext();

            var newsCount = context.News.Count();
        }
    }
}
