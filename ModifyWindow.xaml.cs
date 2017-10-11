using System.Windows;
using DB;

namespace EntityCatalog
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        public ModifyWindow(Book SelectedBook)
        {
            InitializeComponent();
            TitleTB.Text = SelectedBook.Title;
            AuthorTB.Text = SelectedBook.Author;
            GenreTB.Text = SelectedBook.Genre;
            this.ShowDialog();
        }

        public ModifyWindow(Movie SelectedMovie)
        {
            InitializeComponent();
            TitleTB.Text = SelectedMovie.Title;
            AuthorLbl.Content = "Rendező";
            AuthorTB.Text = SelectedMovie.Director;
            GenreTB.Text = SelectedMovie.Genre;
            this.ShowDialog();
        }
    }
}
