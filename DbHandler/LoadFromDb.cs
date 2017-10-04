using DB;
using System.Collections.Generic;
using System.Linq;

namespace DbHandler
{
    public class LoadFromDb
    {
        public static List<Book> LoadAllBooks()
        {
            List<Book> books = new List<Book>();

            using (var db = new CatalogContext())
            {
                var query = from b in db.Books
                            select b;

                foreach (var item in query)
                {
                    books.Add(item);
                }
            }
            return books;
        }

        public static List<Book> LoadSearchedBooks(string searchedText)
        {
            List<Book> books = new List<Book>();

            using (var db = new CatalogContext())
            {
                var query = from b in db.Books
                            where b.Title.Contains(searchedText) || b.Author.Contains(searchedText) || b.Genre.Contains(searchedText)
                            select b;

                foreach (var item in query)
                {
                    books.Add(item);
                }
            }
            return books;
        }

    }
}
