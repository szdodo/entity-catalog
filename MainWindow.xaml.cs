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
            Window newBookWindow= new NewDataWindow();
            if (PresentationSource.FromVisual(newBookWindow) == null)
            {
                loadedBooks = LoadFromDb.LoadAllBooks();
                loadedMovies = LoadFromDb.LoadAllMovies();
            }
        }

        private void CreateBookColumns()
        {
            GridView grdView = new GridView();
            grdView.AllowsColumnReorder = true;
            grdView.ColumnHeaderToolTip = "Könyvek";

            GridViewColumn idColumn = new GridViewColumn();
            idColumn.DisplayMemberBinding = new System.Windows.Data.Binding("BookId");
            idColumn.Header = "Id";
            idColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(idColumn);

            GridViewColumn titleColumn = new GridViewColumn();
            titleColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Title");
            titleColumn.Header = "Cím";
            titleColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(titleColumn);

            GridViewColumn authorColumn = new GridViewColumn();
            authorColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Author");
            authorColumn.Header = "Szerző";
            authorColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(authorColumn);

            GridViewColumn genreColumn = new GridViewColumn();
            genreColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Genre");
            genreColumn.Header = "Műfaj";
            genreColumn.Width = DataLV.ActualWidth / 4;
            grdView.Columns.Add(genreColumn);

            DataLV.View = grdView;
        }

        private void CreateMovieColumns()
        {
            GridView grdView = new GridView();
            grdView.AllowsColumnReorder = true;
            grdView.ColumnHeaderToolTip = "Filmek";

            GridViewColumn idColumn = new GridViewColumn();
            idColumn.DisplayMemberBinding = new System.Windows.Data.Binding("MovieId");
            idColumn.Header = "Id";
            idColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(idColumn);

            GridViewColumn titleColumn = new GridViewColumn();
            titleColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Title");
            titleColumn.Header = "Cím";
            titleColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(titleColumn);

            GridViewColumn directorColumn = new GridViewColumn();
            directorColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Director");
            directorColumn.Header = "Rendező";
            directorColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(directorColumn);

            GridViewColumn genreColumn = new GridViewColumn();
            genreColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Genre");
            genreColumn.Header = "Műfaj";
            genreColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(genreColumn);

            GridViewColumn actorsColumn = new GridViewColumn();
            actorsColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Actors");
            actorsColumn.Header = "Színészek";
            actorsColumn.Width = DataLV.ActualWidth / 5;
            grdView.Columns.Add(actorsColumn);

            DataLV.View = grdView;
        }
        //amikor hozzáadunk v törlünk v módosítunk frissüljön a lista!
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
            bool searched = false;
            if (BookCB.IsChecked ?? true)
            {
                CreateBookColumns();
                DataLV.ItemsSource = Sorter.SearchBookByText(loadedBooks, SearchTB.Text);
                searched = true;
            }
            else
            {
                CreateMovieColumns();
                List<Movie> source = new List<Movie>();
                if (DvdCB.IsChecked ?? true)
                {
                    source.AddRange(Sorter.SearchDvdByText(loadedMovies, SearchTB.Text));
                    searched = true;
                }
                if (VhsCB.IsChecked ?? true)
                {
                    source.AddRange(Sorter.SearchVhsByText(loadedMovies, SearchTB.Text));
                    searched = true;
                }
                
                DataLV.ItemsSource = source;
            }
            if (!searched)
            {

                MessageBox.Show("Kérem előbb válassza ki, hogy milyen kategóriában szeretne keresni.");
            }

            if (DataLV.ItemsSource == null)
            {
                MessageBox.Show("Nincs találat.");
            }
        }

        private void SearchTB_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTB.Text = "";
        }

        //amikor újra listáz nullreference errort ad
        private void DataLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = DataLV.SelectedItem.GetType();
            if (type.ToString() == "DB.Book")
            {
                Window newBookWindow = new ModifyWindow((Book)DataLV.SelectedItem);

            }
            else {
                Window newBookWindow = new ModifyWindow((Movie)DataLV.SelectedItem);

            }
            
            //Book type = (Book)DataLV.SelectedItem;
            var type2 = type.ToString();

        }
    }
}
