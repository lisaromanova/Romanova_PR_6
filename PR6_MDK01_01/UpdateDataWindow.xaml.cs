using PR6_MDK01_01.Classes;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PR6_MDK01_01
{
    /// <summary>
    /// Логика взаимодействия для UpdateDataWindow.xaml
    /// </summary>
    public partial class UpdateDataWindow : Window
    {
        Logined log;
        public UpdateDataWindow(Logined log)
        {
            InitializeComponent();
            this.log = log;
            cbDepartment.ItemsSource = DataBaseClass.connect.Departments.ToList();
            cbDepartment.SelectedValuePath = "IdDepartment";
            cbDepartment.DisplayMemberPath = "Department";
            cbKurs.ItemsSource = DataBaseClass.connect.Kurses.ToList();
            cbKurs.SelectedValuePath = "IdKurs";
            cbKurs.DisplayMemberPath = "Kurs";
            cbSpecialization.ItemsSource = DataBaseClass.connect.Specializations.ToList();
            cbSpecialization.SelectedValuePath = "IdSpecialization";
            cbSpecialization.DisplayMemberPath = "Specialization";
            cbFormOfTraining.ItemsSource = DataBaseClass.connect.FormOfTrainings.ToList();
            cbFormOfTraining.SelectedValuePath = "IdFormOfTraining";
            cbFormOfTraining.DisplayMemberPath = "FormOfTraining";
            cbGroup.ItemsSource = DataBaseClass.connect.Groups.ToList();
            cbGroup.SelectedValuePath = "IdGroup";
            cbGroup.DisplayMemberPath = "NameGroup";
            cbTitle.ItemsSource = DataBaseClass.connect.Titles.ToList();
            cbTitle.SelectedValuePath = "IdTitle";
            cbTitle.DisplayMemberPath = "Title";
            switch (log.IdRole)
            {
                case 1:
                    case 3:
                    TeacherData.Visibility= Visibility.Visible;
                    tbSurname.Text = log.Teachers.Surname;
                    tbName.Text = log.Teachers.NameTeacher;
                    tbPatronymic.Text = log.Teachers.Patronymic;
                    dtBirthday.SelectedDate = log.Teachers.Birthday;
                    switch (log.Teachers.IdGender)
                    {
                        case 1:
                            rbMan.IsChecked= true; 
                            break;
                        case 2:
                            rbWoman.IsChecked = true;
                            break;
                    }
                    cbDepartment.SelectedValue = log.Teachers.IdDepartment;
                    cbTitle.SelectedValue = log.Teachers.IdTitle;
                    tbBet.Text = log.Teachers.Bet.ToString();
                    break;
                case 2:
                    StudentData.Visibility = Visibility.Visible;
                    tbSurname.Text = log.Students.Surname;
                    tbName.Text = log.Students.NameStudent;
                    tbPatronymic.Text = log.Students.Patronymic;
                    dtBirthday.SelectedDate = log.Students.Birthday;
                    switch (log.Students.IdGender)
                    {
                        case 1:
                            rbMan.IsChecked = true;
                            break;
                        case 2:
                            rbWoman.IsChecked = true;
                            break;
                    }
                    cbSpecialization.SelectedValue = log.Students.IdSpecialization;
                    cbKurs.SelectedValue = log.Students.IdKurs;
                    cbFormOfTraining.SelectedValue = log.Students.IdFormOfTraining;
                    cbGroup.SelectedValue = log.Students.IdGroup;
                    break;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        static bool IsClear(string surname, string name, string patronymic, string date)
        {
            if (Regex.IsMatch(surname, "^[А-Я][а-я]+$"))
            {
                if (Regex.IsMatch(name, "^[А-Я][а-я]+$"))
                {
                    if (Regex.IsMatch(patronymic, "^[А-Я][а-я]+$"))
                    {
                        if (date != "")
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Выберите дату рождения", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите Отчество корректно", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя корректно", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите Фамилию корректно", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        static bool IsClearTeacher(string bet)
        {
            if (Regex.IsMatch(bet, "^[0-9]+[,]*[0-9]*$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Введите ставку корректно!", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }

        private void btnUpdateData_Click(object sender, RoutedEventArgs e)
        {
            if(IsClear(tbSurname.Text, tbName.Text, tbPatronymic.Text, dtBirthday.Text))
            {
                int gender;
                if (rbMan.IsChecked == true)
                {
                    gender = 1;
                }
                else
                {
                    gender = 2;
                }
                if (log.IdRole == 2)
                {
                    log.Students.Surname = tbSurname.Text;
                    log.Students.NameStudent = tbName.Text;
                    log.Students.Patronymic = tbPatronymic.Text;
                    log.Students.Birthday = (DateTime)dtBirthday.SelectedDate;
                    log.Students.IdGender = gender;
                    log.Students.IdSpecialization = (int)cbSpecialization.SelectedValue;
                    log.Students.IdKurs = (int)cbKurs.SelectedValue;
                    log.Students.IdFormOfTraining = (int)cbFormOfTraining.SelectedValue;
                    log.Students.IdGroup = (int)cbGroup.SelectedValue;
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Данные успешно изменены!", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    if (IsClearTeacher(tbBet.Text))
                    {
                        log.Teachers.Surname = tbSurname.Text;
                        log.Teachers.NameTeacher = tbName.Text;
                        log.Teachers.Patronymic = tbPatronymic.Text;
                        log.Teachers.Birthday = (DateTime)dtBirthday.SelectedDate;
                        log.Teachers.IdGender = gender;
                        log.Teachers.IdDepartment = (int)cbDepartment.SelectedValue;
                        log.Teachers.IdTitle = (int)cbTitle.SelectedValue;
                        log.Teachers.Bet = Convert.ToDouble(tbBet.Text);
                        DataBaseClass.connect.SaveChanges();
                        MessageBox.Show("Данные успешно изменены!", "Изменение личных данных", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
            }
        }        
    }
}
