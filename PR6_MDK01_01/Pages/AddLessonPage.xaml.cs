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
    /// Логика взаимодействия для AddLessonPage.xaml
    /// </summary>
    public partial class AddLessonPage : Page
    {
        Teachers teacher;
        public AddLessonPage(Teachers ls)
        {
            InitializeComponent();
            teacher = ls;
            tbTeacher.Text = teacher.ShortName;
            cbGroup.ItemsSource = DataBaseClass.connect.StudyPlan.Where(x => x.IdTeacher == ls.IdTeacher).ToList();
            cbGroup.SelectedValuePath = "IdGroup";
            cbGroup.DisplayMemberPath = "Groups.NameGroup";
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new LessonsPage(teacher));
        }


        bool IsClear(int group, int discipline, int type, string date)
        {
            if (group != -1)
            {
                if (discipline != -1)
                {
                    if (type != -1)
                    {
                        if (date != "")
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Выберите дату", "Добавление занятия", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите преподавателя из списка", "Добавление занятия", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите вид отчетности из списка", "Добавление занятия", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Выберите группу из списка", "Добавление занятия", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void TypeLesson()
        {
            
        }

        private void cbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbGroup.SelectedIndex != -1)
            {
                cbDisc.Visibility = Visibility.Visible;
                cbDisc.ItemsSource = DataBaseClass.connect.StudyPlan.Where(x => x.IdGroup == (int)cbGroup.SelectedValue && (x.Lecture != 0 || x.Practice != 0)).ToList();
                cbDisc.SelectedValuePath = "IdDiscipline";
                cbDisc.DisplayMemberPath = "Disciplines.Discipline";
            }
            
        }
    }
}
