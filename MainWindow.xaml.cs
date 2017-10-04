﻿using System.Windows;
using DB;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Controls;

namespace EntityCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }

        private void AddNewBook()
        {
            using (var db = new CatalogContext())
            {
                var book = new Book { Title = "probacím2", Author = "próbaszerző2" };
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        private void LoadBooks()
        {
            CreateBookColumns();

            using (var db = new CatalogContext())
            {
                var query = from b in db.Books
                            select b;

                List<Book> books = new List<Book>();
                foreach (var item in query)
                {
                    books.Add(item);
                }
                lw.ItemsSource = books;
            }
        }

        private void CreateBookColumns()
        {
            GridView grdView = new GridView();
            grdView.AllowsColumnReorder = true;
            grdView.ColumnHeaderToolTip = "Books";

            GridViewColumn idColumn = new GridViewColumn();
            idColumn.DisplayMemberBinding = new System.Windows.Data.Binding("BookId");
            idColumn.Header = "Id";
            idColumn.Width = lw.ActualWidth / 4;
            grdView.Columns.Add(idColumn);

            GridViewColumn titleColumn = new GridViewColumn();
            titleColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Title");
            titleColumn.Header = "Title";
            titleColumn.Width = lw.ActualWidth / 4;
            grdView.Columns.Add(titleColumn);

            GridViewColumn authorColumn = new GridViewColumn();
            authorColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Author");
            authorColumn.Header = "Author";
            authorColumn.Width = lw.ActualWidth / 4;
            grdView.Columns.Add(authorColumn);

            GridViewColumn genreColumn = new GridViewColumn();
            genreColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Genre");
            genreColumn.Header = "Genre";
            genreColumn.Width = lw.ActualWidth / 4;
            grdView.Columns.Add(genreColumn);

            lw.View = grdView;
        }

        private void CreateMovieColumns()
        {
            GridView grdView = new GridView();
            grdView.AllowsColumnReorder = true;
            grdView.ColumnHeaderToolTip = "Movies";

            GridViewColumn idColumn = new GridViewColumn();
            idColumn.DisplayMemberBinding = new System.Windows.Data.Binding("MovieId");
            idColumn.Header = "Id";
            idColumn.Width = lw.ActualWidth / 5;
            grdView.Columns.Add(idColumn);

            GridViewColumn titleColumn = new GridViewColumn();
            titleColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Title");
            titleColumn.Header = "Title";
            titleColumn.Width = lw.ActualWidth / 5;
            grdView.Columns.Add(titleColumn);

            GridViewColumn directorColumn = new GridViewColumn();
            directorColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Director");
            directorColumn.Header = "Author";
            directorColumn.Width = lw.ActualWidth / 5;
            grdView.Columns.Add(directorColumn);

            GridViewColumn genreColumn = new GridViewColumn();
            genreColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Genre");
            genreColumn.Header = "Genre";
            genreColumn.Width = lw.ActualWidth / 5;
            grdView.Columns.Add(genreColumn);

            GridViewColumn actorsColumn = new GridViewColumn();
            actorsColumn.DisplayMemberBinding = new System.Windows.Data.Binding("Actors");
            actorsColumn.Header = "Actors";
            actorsColumn.Width = lw.ActualWidth / 5;
            grdView.Columns.Add(actorsColumn);

            lw.View = grdView;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //check which one  is chosen
            //resize columns
            if (BookCB.IsChecked ?? true)
            {
                CreateBookColumns();
                LoadBooks();
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
    }
}