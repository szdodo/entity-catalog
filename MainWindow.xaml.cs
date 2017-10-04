using DB;
using DbHandler;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataHandler;

namespace EntityCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> loadedBooks;
        List<Movie> loadedMovies;

        public MainWindow()
        {
            InitializeComponent();
            loadedBooks = LoadFromDb.LoadAllBooks();
            loadedMovies = LoadFromDb.LoadAllMovies();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddToDb.AddNewBook("új könyv", "új szerző", "új műfaj");
            //AddToDb.AddNewMovie("új dvd", "új rendező", "új műfaj", true);
            CreateBookColumns();
            DataLV.ItemsSource = loadedBooks;
        }

        private void CreateBookColumns()
        {
            GridView grdView = new GridView();
            grdView.AllowsColumnReorder = true;
            grdView.ColumnHeaderToolTip = "Books";

            GridViewColumn idColumn = new GridViewColumn();
            idColumn.DisplayMemberBinding = new System.Windows.Data.Binding("BookId");
            idColumn.Header = "Id";
            idColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(idColumn);

            GridViewColumn titleColumn = new GridViewColumn();
            titleColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Title");
            titleColumn.Header = "Title";
            titleColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(titleColumn);

            GridViewColumn authorColumn = new GridViewColumn();
            authorColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Author");
            authorColumn.Header = "Author";
            authorColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(authorColumn);

            GridViewColumn genreColumn = new GridViewColumn();
            genreColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Genre");
            genreColumn.Header = "Genre";
            genreColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(genreColumn);

            DataLV.View = grdView;
        }

        private void CreateMovieColumns()
        {
            GridView grdView = new GridView();
            grdView.AllowsColumnReorder = true;
            grdView.ColumnHeaderToolTip = "Movies";

            GridViewColumn idColumn = new GridViewColumn();
            idColumn.DisplayMemberBinding = new System.Windows.Data.Binding("MovieId");
            idColumn.Header = "Id";
            idColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(idColumn);

            GridViewColumn titleColumn = new GridViewColumn();
            titleColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Title");
            titleColumn.Header = "Title";
            titleColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(titleColumn);

            GridViewColumn directorColumn = new GridViewColumn();
            directorColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Director");
            directorColumn.Header = "Author";
            directorColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(directorColumn);

            GridViewColumn genreColumn = new GridViewColumn();
            genreColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Genre");
            genreColumn.Header = "Genre";
            genreColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(genreColumn);

            GridViewColumn actorsColumn = new GridViewColumn();
            actorsColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Actors");
            actorsColumn.Header = "Actors";
            actorsColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(actorsColumn);

            DataLV.View = grdView;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //check which one  is chosen
            //resize columns
            if (BookCB.IsChecked ?? true)
            {
                CreateBookColumns();
                //LoadBooks();
            }
            else
            {
                CreateMovieColumns();
                if (DvdCB.IsChecked ?? true)
                {
                    //load dvd
                }
                else
                {
                    //load vhs
                }
            }

        }

        private void BookCB_Checked(object sender, RoutedEventArgs e)
        {
            DvdCB.IsChecked = false;
            VhsCB.IsChecked = false;
        }

        private void DvdCB_Checked(object sender, RoutedEventArgs e)
        {
            BookCB.IsChecked = false;
        }

        private void VhsCB_Checked(object sender, RoutedEventArgs e)
        {
            BookCB.IsChecked = false;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BookCB.IsChecked ?? true)
            {
                CreateBookColumns();
                DataLV.ItemsSource = Sorter.SearchBookByText(loadedBooks, SearchTB.Text);
            }else if (DvdCB.IsChecked ?? true){
                CreateMovieColumns();
                DataLV.ItemsSource = LoadFromDb.LoadSearchedMovies(true, SearchTB.Text);
            } else if (VhsCB.IsChecked ?? true)
            {
                CreateMovieColumns();
                DataLV.ItemsSource = LoadFromDb.LoadSearchedMovies(true, SearchTB.Text);
            }
            else
            {
                MessageBox.Show("Kérem előbb válassza ki, hogy milyen kategóriában szeretne keresni.");
            }
        }

        private void SearchTB_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTB.Text = "";
        }
    }
}
