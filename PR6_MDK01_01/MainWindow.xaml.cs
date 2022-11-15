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
using PR6_MDK01_01.Pages;

namespace PR6_MDK01_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool Check=false;
        public static string ShortName = "";
        public static Logined log;
        public MainWindow()
        {
            InitializeComponent();
            DataBaseClass.connect = new DataBaseEntities();
            FrameClass.frmLoad = frmMain;
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new AuthorizationPage());
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new RegistrationPage());
        }


        private void frmMain_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (Check == true)
            {
                buttons.Visibility = Visibility.Collapsed;
                spUser.Visibility = Visibility.Visible;
                HeaderMenu.Text = ShortName;
            }
            else
            {
                buttons.Visibility = Visibility.Visible;
                spUser.Visibility = Visibility.Collapsed;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult i = MessageBox.Show("Вы точно хотите выйти из программы?", "Выход из программы", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(i== MessageBoxResult.Yes)
            {
                FrameClass.frmLoad.Navigate(new AuthorizationPage());
                Check = false;
            }
        }

        private void menuUser_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new UserPage(log));
        }
    }
}
