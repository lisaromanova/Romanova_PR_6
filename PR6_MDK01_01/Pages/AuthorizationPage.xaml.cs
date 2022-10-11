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
using PR6_MDK01_01.Classes;
namespace PR6_MDK01_01.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            int password = pswPassword.Password.GetHashCode();
            Logined log = DataBaseClass.connect.Logined.FirstOrDefault(x => x.LoginUser == tbLogin.Text && x.PasswordUser == password);
            if(log != null)
            {
                MessageBox.Show("Успешная авторизация!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
