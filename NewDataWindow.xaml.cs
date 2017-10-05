using System.Windows;
using DataHandler;
using DbHandler;

namespace EntityCatalog
{
    /// <summary>
    /// Interaction logic for NewDataWindow.xaml
    /// </summary>
    public partial class NewDataWindow : Window
    {
        public NewDataWindow()
        {
            InitializeComponent();
            BookCB.IsChecked = false;
            DvdCB.IsChecked = false;
            VhsCB.IsChecked = false;
            this.ShowDialog();
        }

        private void BookCB_Checked(object sender, RoutedEventArgs e)
        {
            DvdCB.IsChecked = false;
            VhsCB.IsChecked = false;
            AuthorLbl.Content = "Szerző:";
        }

        private void DvdCB_Checked(object sender, RoutedEventArgs e)
        {
            BookCB.IsChecked = false;
            VhsCB.IsChecked = false;
            AuthorLbl.Content = "Rendező:";
        }

        private void VhsCB_Checked(object sender, RoutedEventArgs e)
        {
            BookCB.IsChecked = false;
            DvdCB.IsChecked = false;
            AuthorLbl.Content = "Rendező:";
        }

        private void NewBookBtn_Click(object sender, RoutedEventArgs e)
        {
            //input check kell h mert szar a db modellem is mehet bele null is oda ahova nem!
            if ((BookCB.IsChecked ?? true) || (DvdCB.IsChecked ?? true) || (VhsCB.IsChecked ?? true))
            {
                if (InputChecker.InputNotNull(TitleTB.Text) && InputChecker.InputNotNull(AuthorTB.Text) && InputChecker.InputNotNull(GenreTB.Text))
                {
                    MessageBox.Show("OK");
                    SaveToDb();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("nem ok!");
                }
            }
            else
            {
                MessageBox.Show("Kérem válasszon egy kategóriát!");
            }
        }

        private void SaveToDb()
        {
            if (BookCB.IsChecked ?? true)
            {
                AddToDb.AddNewBook(TitleTB.Text, AuthorTB.Text, GenreTB.Text);
            }
            if (DvdCB.IsChecked ?? true)
            {
                AddToDb.AddNewMovie(TitleTB.Text, AuthorTB.Text, GenreTB.Text, true);
            }
            if(VhsCB.IsChecked ?? true)
            {
                AddToDb.AddNewMovie(TitleTB.Text, AuthorTB.Text, GenreTB.Text, false);
            }
        }
    }
}
