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
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
        public signup()
        {
            InitializeComponent();
        }

       

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            using (libraryEntities db = new libraryEntities())
            {
                User user = new User();

                if (string.IsNullOrEmpty(PasswordBox.Password) || string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(UsernameTextBox.Text))
                {

                    MessageBox.Show("please enter full data");
                }

                if (PasswordBox.Password != ConfirmPasswordBox.Password)
                {
                    MessageBox.Show("enter the same passowrd");
                }
                string radio = "";
                if (m_radio.IsChecked == true)
                {
                    radio = "member";

                }
                else
                {
                        radio = "librian";
                }

                user.Email = EmailTextBox.Text;
                user.Password = PasswordBox.Password;
                user.FullName = UsernameTextBox.Text;
                user.Role = radio;
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("account created successful");

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new login());

        }
    }
}
