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
    }
}
