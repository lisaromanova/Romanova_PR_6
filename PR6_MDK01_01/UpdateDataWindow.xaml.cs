using PR6_MDK01_01.Classes;
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
    }
}
