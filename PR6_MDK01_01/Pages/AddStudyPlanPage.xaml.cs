using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddStudyPlanPage.xaml
    /// </summary>
    public partial class AddStudyPlanPage : Page
    {
        public AddStudyPlanPage()
        {
            InitializeComponent();
            cbGroup.ItemsSource = DataBaseClass.connect.Groups.ToList();
            cbGroup.SelectedValuePath = "IdGroup";
            cbGroup.DisplayMemberPath = "NameGroup";
            cbDisc.ItemsSource = DataBaseClass.connect.Disciplines.ToList();
            cbDisc.SelectedValuePath = "IdDiscipline";
            cbDisc.DisplayMemberPath = "Discipline";
            cbTypeReport.ItemsSource = DataBaseClass.connect.TypesOfReporting.ToList();
            cbTypeReport.SelectedValuePath = "IdTypeOfReporting";
            cbTypeReport.DisplayMemberPath = "TypeOfReporting";
            cbTeacher.ItemsSource = DataBaseClass.connect.Teachers.ToList();
            cbTeacher.SelectedValuePath = "IdTeacher";
            cbTeacher.DisplayMemberPath = "ShortName";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new ListViewPage());
        }

        bool CheckField(int group, int type, int teacher)
        {
            if (group != -1)
            {
                if (type != -1)
                {
                    if (teacher != -1)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Выберите преподавателя из списка", "Добавление учебного плана", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите вид отчетности из списка", "Добавление учебного плана", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Выберите группу из списка", "Добавление учебного плана", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        bool CheckInt(string ch, string str)
        {
            if(Regex.IsMatch(ch, "^\\d+$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"Заполните {str} часы!", "Добавление учебного плана", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        bool CheckDisc(string disc)
        {
            if (Regex.IsMatch(disc, "^[А-Я][а-я]+$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Введите дисциплину корректно или выберите из списка!", "Добавление учебного плана", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        bool CheckPlan(int group, int discipline)
        {
            StudyPlan sp = DataBaseClass.connect.StudyPlan.FirstOrDefault(x => x.IdGroup == group && x.IdDiscipline == discipline);
            if(sp == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("В выбранной группе уже есть такая дисциплина!", "Добавление учебного плана", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(CheckField(cbGroup.SelectedIndex, cbTypeReport.SelectedIndex, cbTeacher.SelectedIndex))
            {
                if (CheckInt(tbLecture.Text, "лекционные"))
                {
                    if(CheckInt(tbPractice.Text, "практические"))
                    {
                        int Iddisc = 0;
                        Disciplines disciplines = DataBaseClass.connect.Disciplines.FirstOrDefault(x => x.Discipline == cbDisc.Text);
                        if (disciplines == null)
                        {
                            if (CheckDisc(cbDisc.Text))
                            {
                                Disciplines d = new Disciplines()
                                {
                                    Discipline = cbDisc.Text
                                };
                                DataBaseClass.connect.Disciplines.Add(d);
                                Iddisc = d.IdDiscipline;
                            }
                        }
                        else
                        {
                            Iddisc = (int)cbDisc.SelectedValue;
                        }
                        if (CheckPlan((int)cbGroup.SelectedValue, Iddisc))
                        {
                            
                            StudyPlan st = new StudyPlan()
                            {
                                IdGroup = (int)cbGroup.SelectedValue,
                                IdDiscipline = Iddisc,
                                Lecture = Convert.ToInt32(tbLecture.Text),
                                Practice = Convert.ToInt32(tbPractice.Text),
                                IdTypeOfReporting = (int)cbTypeReport.SelectedValue,
                                General = Convert.ToInt32(tbLecture.Text) + Convert.ToInt32(tbPractice.Text),
                                IdTeacher = (int)cbTeacher.SelectedValue
                            };
                            DataBaseClass.connect.StudyPlan.Add(st);
                            DataBaseClass.connect.SaveChanges();
                            MessageBox.Show("Запись успешно добавлена!", "Добавление учебного плана", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
        }
    }
}
