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
                    books.Add(new Book { BookId = item.BookId, Title = item.Title, Author = item.Author, Genre = item.Genre });
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

        public static List<Movie> LoadAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            using (var db = new CatalogContext())
            {
                var query = from b in db.Movies
                            select b;

                foreach (var item in query)
                {
                    movies.Add(item);
                }
            }
            return movies;
        }

        public static List<Movie> LoadSearchedMovies(bool isDvd, string searchedText)
        {
            List<Movie> movies = new List<Movie>();

            using (var db = new CatalogContext())
            {
                var query = from b in db.Movies
                            where b.Dvd == isDvd && b.Title.Contains(searchedText) || b.Director.Contains(searchedText) || b.Genre.Contains(searchedText) 
                            select b;

                foreach (var item in query)
                {
                    movies.Add(item);
                }
            }
            return movies;
        }

    }
}
