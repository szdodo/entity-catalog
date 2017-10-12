using System.Windows;
using DB;
using DbHandler;

namespace EntityCatalog
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        int id;

        public ModifyWindow(Book SelectedBook)
        {
            InitializeComponent();
            id = SelectedBook.BookId;
            TitleTB.Text = SelectedBook.Title;
            AuthorTB.Text = SelectedBook.Author;
            GenreTB.Text = SelectedBook.Genre;
            this.ShowDialog();
        }

        public ModifyWindow(Movie SelectedMovie)
        {
            InitializeComponent();
            id = SelectedMovie.MovieId;
            TitleTB.Text = SelectedMovie.Title;
            AuthorLbl.Content = "Rendező";
            AuthorTB.Text = SelectedMovie.Director;
            GenreTB.Text = SelectedMovie.Genre;
            this.ShowDialog();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ModifyBtn_Click(object sender, RoutedEventArgs e)
        {
            ModifyRecord.UpdateBook(id, TitleTB.Text, AuthorTB.Text, GenreTB.Text);
            this.Close();
        }
    }
}
