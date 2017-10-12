using DB;
using System.Linq;

namespace DbHandler
{
    public class ModifyRecord
    {
        public static void UpdateBook(int id, string NewTitle = null, string NewAthor = null, string NewGenre = null)
        {
            using (var db = new CatalogContext())
            {
                var result = (from p in db.Books
                              where p.BookId == id
                              select p).SingleOrDefault();
                if (NewTitle != null) { result.Title = NewTitle; }
                if (NewAthor != null) { result.Author = NewAthor; }
                if (NewGenre != null) { result.Genre = NewGenre; }
                db.SaveChanges();
            }
        }


    }
}
