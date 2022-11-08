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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        
        public AdminPage()
        {
            InitializeComponent();
            btnView.Content = "Просмотр данных\nо преподавателях";
            btnView2.Content = "Просмотр карточек\nпреподавателей";
            btnView3.Content = "Просмотр занятий";
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new ViewTeacherPage());
        }

        private void btnView2_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new ListViewPage());
        }

        private void btnView3_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new CalendarPage());
        }
    }
}
