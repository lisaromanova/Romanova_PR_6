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
        StudyPlan st;
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
                        MessageBox.Show("Выберите вид занятия из списка", "Добавление занятия", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if ((cbGroup.SelectedIndex != -1) && (cbDisc.SelectedIndex != -1))
            {
                cbTypeLesson.Visibility = Visibility.Visible;
                st = DataBaseClass.connect.StudyPlan.FirstOrDefault(x => x.IdGroup == (int)cbGroup.SelectedValue && x.IdDiscipline == (int)cbDisc.SelectedValue && x.IdTeacher==teacher.IdTeacher);
                if (st.Lecture == 0)
                {
                    cbTypeLesson.ItemsSource = DataBaseClass.connect.TypesOfLesson.Where(x => x.IdTypeOfLesson == 2).ToList();
                }
                else
                {
                    if (st.Practice == 0)
                    {
                        cbTypeLesson.ItemsSource = DataBaseClass.connect.TypesOfLesson.Where(x => x.IdTypeOfLesson == 1).ToList();
                    }
                    else
                    {
                        cbTypeLesson.ItemsSource = DataBaseClass.connect.TypesOfLesson.ToList();
                    }
                }
                cbTypeLesson.SelectedValuePath = "IdTypeOfLesson";
                cbTypeLesson.DisplayMemberPath = "TypeOfLesson";
            }
        }

        private void cbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbGroup.SelectedIndex != -1)
            {
                cbDisc.Visibility = Visibility.Visible;
                cbDisc.ItemsSource = DataBaseClass.connect.StudyPlan.Where(x => x.IdGroup == (int)cbGroup.SelectedValue && (x.Lecture != 0 || x.Practice != 0)).ToList();
                cbDisc.SelectedValuePath = "IdDiscipline";
                cbDisc.DisplayMemberPath = "Disciplines.Discipline";
                TypeLesson();
            }
            
        }

        private void cbDisc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeLesson();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(IsClear(cbGroup.SelectedIndex, cbDisc.SelectedIndex, cbTypeLesson.SelectedIndex, dtLesson.Text))
            {
                Lessons lesson = new Lessons()
                {
                    IdGroup = (int)cbGroup.SelectedValue,
                    IdDiscipline = (int)cbDisc.SelectedValue,
                    IdTypeOfLesson = (int)cbTypeLesson.SelectedValue,
                    IdTeacher = teacher.IdTeacher,
                    DateLesson = (DateTime)dtLesson.SelectedDate
                };
                DataBaseClass.connect.Lessons.Add(lesson);
                if (lesson.IdTypeOfLesson == 1)
                {
                    st.Lecture -= 2;
                }
                else
                {
                    st.Practice -= 2;
                }
                DataBaseClass.connect.SaveChanges();
                MessageBox.Show("Занятие успешно добавлено!", "Добавление занятия", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
