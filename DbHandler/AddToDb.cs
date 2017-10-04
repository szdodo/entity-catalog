using DB;
using System.Collections.Generic;

namespace DbHandler
{
    public class AddToDb
    {
        public static void AddNewBook(string newTitle, string newAuthor, string newGenre)
        {
            using (var db = new CatalogContext())
            {
                var book = new Book { Title = newTitle, Author = newAuthor, Genre = newGenre };
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public static void AddNewBook(Book newBook)
        {
            using (var db = new CatalogContext())
            {
                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public static void AddNewMovie(string newTitle, string newDirector, string newGenre, bool newDvd, List<Actor> newActors=null)
        {
            using (var db = new CatalogContext())
            {
                var movie = new Movie { Title = newTitle, Director = newDirector, Genre = newGenre, Dvd=newDvd, Actors=newActors};
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        public static void AddNewMovie(Movie newMovie)
        {
            using (var db = new CatalogContext())
            {
                db.Movies.Add(newMovie);
                db.SaveChanges();
            }
        }


    }
}
