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
    /// Логика взаимодействия для LessonsPage.xaml
    /// </summary>
    public partial class LessonsPage : Page
    {
        List<Lessons> list;
        Teachers teacher;
        public LessonsPage(Teachers ls)
        {
            InitializeComponent();
            teacher = ls;
            list = DataBaseClass.connect.Lessons.Where(x=> x.IdTeacher==ls.IdTeacher).ToList();
            lbLessons.ItemsSource = list;
            txtTeacher.Text += ls.ShortName;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new ListViewPage());
        }

        private void btnAddLesson_Click(object sender, RoutedEventArgs e)
        {

            FrameClass.frmLoad.Navigate(new AddLessonPage(teacher));
        }
    }
}
