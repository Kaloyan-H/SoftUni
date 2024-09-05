namespace BookShop
{
    using Models;
    using Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Text;
    using Z.EntityFramework.Extensions;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //Console.WriteLine(GetBooksByAgeRestriction(db, "teEn"));
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            //Console.WriteLine(GetBooksNotReleasedIn(db, 1998));
            //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
            //Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));
            //Console.WriteLine(GetBookTitlesContaining(db, "sK"));
            //Console.WriteLine(GetBooksByAuthor(db, "R"));
            //Console.WriteLine(CountBooks(db, 40));
            //Console.WriteLine(CountCopiesByAuthor(db));
            //Console.WriteLine(GetTotalProfitByCategory(db));
            //Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
            //Console.WriteLine(RemoveBooks(db));
        }

        // Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                var bookTitles = context.Books
                    .AsNoTracking()
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            try
            {
                EditionType edition = Enum.Parse<EditionType>("Gold", true);

                var bookTitles = context.Books
                    .AsNoTracking()
                    .Where(b => b.Copies < 5000 && b.EditionType == edition)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .AsNoTracking()
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    Price = b.Price.ToString("f2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context.Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate!.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower());

            var bookTitles = context.Books
                .AsNoTracking()
                .Where(b => b.BookCategories
                            .Select(bc => bc.Category.Name)
                            .Any(c => categories
                                      .Contains(c.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            // First solution that came to mind
            //string[] dateTokens = date.Split('-', StringSplitOptions.RemoveEmptyEntries);
            //DateTime dateTime = new DateTime(int.Parse(dateTokens[2]), int.Parse(dateTokens[1]), int.Parse(dateTokens[0]));

            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    Edition = b.EditionType.ToString(),
                    Price = b.Price.ToString("f2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsFullNames = context.Authors
                .AsNoTracking()
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => string.Join(' ', new string[] { a.FirstName, a.LastName }))
                .ToArray();

            return string.Join(Environment.NewLine, authorsFullNames);
        }

        // Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string containedString = input.ToLower();

            var bookTitles = context.Books
                .AsNoTracking()
                .Where(b => b.Title.ToLower().Contains(containedString))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string comparedString = input.ToLower();

            var books = context.Books
                .AsNoTracking()
                .Where(b => b.Author.LastName.ToLower().StartsWith(comparedString))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = string.Join(' ', new string[] { b.Author.FirstName, b.Author.LastName })
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int countOfBooksWithLongerTitle = context.Books
                .AsNoTracking()
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return countOfBooksWithLongerTitle;
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .AsNoTracking()
                .OrderByDescending(a => a.Books.Sum(b => b.Copies)) // Could be after the .Select, still executed in the DB
                .Select(a => new
                {
                    FullName = string.Join(' ', new string[] { a.FirstName, a.LastName }),
                    TotalBookCopies = a.Books.Sum(b => b.Copies)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .AsNoTracking()
                .OrderByDescending(c => c.CategoryBooks                             //
                                        .Sum(cb => cb.Book.Price * cb.Book.Copies)) // Could be after .Select, still executed in the DB
                .ThenBy(c => c.Name)                                                //
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                                  .Sum(cb => cb.Book.Price * cb.Book.Copies)
                                  .ToString("f2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    TopThreeRecentBooks = c.CategoryBooks
                                          .OrderByDescending(cb => cb.Book.ReleaseDate)
                                          .Take(3)
                                          .Select(cb => new
                                          {
                                              Title = cb.Book.Title,
                                              ReleaseYear = cb.Book.ReleaseDate!.Value.Year
                                          })
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.TopThreeRecentBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            // FASTEST SOLUTION 
            //context.Books
            //    .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
            //    .UpdateFromQuery(b => new Book { Price = b.Price + 5 });

            foreach (var book in books)
            {
                book.Price += 5;
            }

            //context.SaveChanges();    // Slower
            context.BulkUpdate(books);  // Faster
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToBeDeleted = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.BulkDelete(booksToBeDeleted);

            return booksToBeDeleted.Count();
        }
    }
}


