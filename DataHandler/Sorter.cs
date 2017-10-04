using System.Collections.Generic;
using DB;

namespace DataHandler
{
    public class Sorter
    {
        public static List<Book> SearchBookByText(List<Book> books, string searchedText)
        {
            List<Book> searchedList = new List<Book>();
            foreach(Book book in books)
            {
                if (book.Title.Contains(searchedText) || book.Author.Contains(searchedText) || book.Genre.Contains(searchedText)){
                    searchedList.Add(book);
                }
            }
            return searchedList;
        }

        public static List<Movie> SearchDvdByText(List<Movie> movies, string searchedText)
        {
            List<Movie> searchedList = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Dvd && movie.Title.Contains(searchedText) || movie.Director.Contains(searchedText) || movie.Genre.Contains(searchedText))
                {
                    searchedList.Add(movie);
                }
            }
            return searchedList;
        }

        public static List<Movie> SearchVhsByText(List<Movie> movies, string searchedText)
        {
            List<Movie> searchedList = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (!movie.Dvd && movie.Title.Contains(searchedText) || movie.Director.Contains(searchedText) || movie.Genre.Contains(searchedText) || SearchActors(movie, searchedText))
                {
                    searchedList.Add(movie);
                }
            }
            return searchedList;
        }

        private static bool SearchActors(Movie movie, string searchedText)
        {
            foreach(Actor actor in movie.Actors)
            {
                if (actor.Name.Contains(searchedText))
                    return true;
            }
            return false;
        }

    }
}
