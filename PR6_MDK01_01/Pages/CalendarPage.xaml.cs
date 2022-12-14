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
    /// Логика взаимодействия для CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
        }

        private void calendarLessons_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            List<Lessons> list = DataBaseClass.connect.Lessons.Where(x => x.DateLesson == (DateTime)calendarLessons.SelectedDate).ToList();
            lbLessons.ItemsSource = list;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new AdminPage());
        }
    }
}
