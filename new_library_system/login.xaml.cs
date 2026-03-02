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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        User currentuser=new User();
        public login()
        {
            InitializeComponent();
            this.DataContext= currentuser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (libraryEntities db = new libraryEntities())
            {
                // 1. ناخد الباسورد من الـ PasswordBox يدوي (لأن الـ PasswordBox مبيعملش Binding بسهولة)
                string enteredPassword = paswordpox.Password;
                string enteredName = currentuser.FullName;

                // 2. ندور في الداتابيز (غيرنا اسم المتغير لـ foundUser عشان الـ Error)
                var foundUser = db.Users.FirstOrDefault(x => x.Password == enteredPassword && x.FullName == enteredName);

                if (foundUser != null)
                {
                    MessageBox.Show("Login Successful! Welcome " + foundUser.FullName);

                    // 3. التوجيه بناءً على الـ Role اللي اتخزن وقت الـ SignUp
                    if (foundUser.Role == "librian") // تأكد إن السبلنج زي ما هو في الداتابيز
                    {
                        this.NavigationService.Navigate(new librian());
                    }
                    //else
                    //{
                    //    // لو مش ليبراريان يروح لصفحة الفلترة (Page 3)
                    //    this.NavigationService.Navigate(new BookFilterPage());
                    //}
                }
                else
                {
                    MessageBox.Show("Login Failed: Invalid Name or Password");
                }
            }
        }
    }
}
