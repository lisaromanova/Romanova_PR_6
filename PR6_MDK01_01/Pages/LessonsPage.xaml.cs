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
            LoadList();
            txtTeacher.Text += ls.ShortName;
        }

        private void LoadList()
        {
            list = DataBaseClass.connect.Lessons.Where(x => x.IdTeacher == teacher.IdTeacher).ToList();
            list = list.OrderBy(x => x.DateLesson).ToList();
            lbLessons.ItemsSource = list;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new ListViewPage());
        }

        private void btnAddLesson_Click(object sender, RoutedEventArgs e)
        {

            FrameClass.frmLoad.Navigate(new AddLessonPage(teacher));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult i = MessageBox.Show("Вы точно хотите удалить занятие?", "Выход из программы", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (i == MessageBoxResult.Yes)
                {
                    Button button = (Button)sender;
                    int index = Convert.ToInt32(button.Uid);
                    Lessons lesson = DataBaseClass.connect.Lessons.FirstOrDefault(x => x.IdLesson == index);
                    StudyPlan stPlan = DataBaseClass.connect.StudyPlan.FirstOrDefault(x => x.IdTeacher == lesson.IdTeacher && x.IdDiscipline == lesson.IdDiscipline && x.IdGroup == lesson.IdGroup);
                    switch (lesson.IdTypeOfLesson)
                    {
                        case 1:
                            stPlan.Lecture += 2;
                            break;
                        case 2:
                            stPlan.Practice += 2;
                            break;
                    }
                    DataBaseClass.connect.Lessons.Remove(lesson);
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Занятие успешно удалено!", "Удаление занятия", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadList();
                }     
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Удаление занятия", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = Convert.ToInt32(button.Uid);
            Lessons lesson = DataBaseClass.connect.Lessons.FirstOrDefault(x => x.IdLesson == index);
            FrameClass.frmLoad.Navigate(new AddLessonPage(lesson));
        }
    }
}
