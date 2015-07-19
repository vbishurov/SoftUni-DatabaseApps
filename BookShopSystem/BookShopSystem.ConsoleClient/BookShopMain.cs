namespace BookShopSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;

    public static class BookShopMain
    {
        public static void Main()
        {
            var context = new BookShopContext();

            var booksReleaseDate = context.Books.Where(b => b.ReleaseDate.Value.Year > 2000).Select(b => b.Title);

            context.SaveChanges();

            //foreach (string book in booksReleaseDate)
            //{
            //    Console.WriteLine(book);
            //}

            var authors = context.Authors
                .Where(a => a.Books.Any(b => b.ReleaseDate.Value.Year < 1990)).Select(a => new
            {
                a.FirstName,
                a.LastName
            });

            //foreach (var author in authors)
            //{
            //    Console.WriteLine("{0} {1}",author.FirstName,author.LastName);
            //}

            var authorsBookCount = context.Authors
                .OrderByDescending(a => a.Books.Count)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BookCount = a.Books.Count
                });

            //foreach (var author in authorsBookCount)
            //{
            //    Console.WriteLine("{0} {1} - Books: {2}", author.FirstName, author.LastName, author.BookCount);
            //}

            var booksGeorge = context.Books
                .Where(b => b.Author.FirstName == "George" && b.Author.LastName == "Powell")
                .OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.Title)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate,
                    b.Copies
                });

            //foreach (var book in booksGeorge)
            //{
            //    Console.WriteLine("{0}, released on: {1} - Copies: {2}", book.Title, book.ReleaseDate.Value.ToString("d"), book.Copies);
            //}

            var booksByCategory = context.Categories.OrderByDescending(c => c.Books.Count).Select(c => new
            {
                c.Name,
                BookCount = c.Books.Count,
                Books = c.Books.OrderByDescending(b => b.ReleaseDate).ThenBy(b => b.Title).Select(b => new
                {
                    b.Title,
                    b.ReleaseDate
                }).Take(3)
            });

            //foreach (var categoy in booksByCategory)
            //{
            //    Console.WriteLine("--{0}: {1} books{2}{3}",
            //        categoy.Name, categoy.BookCount,
            //        Environment.NewLine,
            //        string.Join(Environment.NewLine, categoy.Books.Select(b => string.Format("{0} ({1})", b.Title, b.ReleaseDate.Value.Year))));
            //}

            //var books = context.Books
            //.Take(3)
            //.ToList();

            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            //context.SaveChanges();

            var booksFromQuery = context.Books.Take(3).Select(b => new
            {
                b.Title,
                b.RelatedBooks
            });

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }

        }
    }
}
