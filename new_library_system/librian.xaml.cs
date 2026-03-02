using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace new_library_system
{
    /// <summary>
    /// Interaction logic for librian.xaml
    /// </summary>
    public partial class librian : Page
    {
        public librian()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (libraryEntities db = new libraryEntities()) 
            {
             Book book= new Book();
                book.Title=txtTitle.Text;
                book.Author=txtAuthor.Text;
                book.Category=txtCategory.Text;
                if (int.TryParse(txtQuantity.Text, out int q))
                {
                    book.Quantity=q;
                }
                db.Books.Add(book);
                db.SaveChanges();
                MessageBox.Show("add done sfssucchhhhhhhhessfull");
                dgBooks.ItemsSource = db.Books.ToList();
            
            }
        }


        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectebook = dgBooks.SelectedItem as Book;
            if (selectebook != null) 
            {
                using (libraryEntities library = new libraryEntities()) 
                {
                 var bookindb=library.Books.FirstOrDefault(b=>b.Id==selectebook.Id);
                    if (bookindb != null) 
                    {
                        bookindb.Title=txtTitle.Text;
                        bookindb.Author=txtAuthor.Text;
                        bookindb.Category=txtCategory.Text;
                    }
                    library.SaveChanges();
                    MessageBox.Show("update successfull");
                    dgBooks.ItemsSource=library.Books.ToList();
                }
            }
            else
            {
                MessageBox.Show("please select a book from the list first to update.");
            }
        }
    }
}
