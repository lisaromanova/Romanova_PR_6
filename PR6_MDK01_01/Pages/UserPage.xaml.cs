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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR6_MDK01_01.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        Logined log;
        public UserPage(Logined login)
        {
            InitializeComponent();
            log = login;
            switch (login.IdRole)
            {
                case 1:
                case 3:
                    txtDepartment.Visibility = Visibility.Visible;
                    txtTitle.Visibility = Visibility.Visible;
                    txtBet.Visibility = Visibility.Visible;

                    txtSurname.Text = login.Teachers.Surname;
                    txtName.Text = login.Teachers.NameTeacher;
                    txtPatronymic.Text = login.Teachers.Patronymic;
                    txtBirthday.Text = login.Teachers.Birthday.ToString("dd.MM.yyyy");
                    txtGender.Text = login.Teachers.Genders.Gender;
                    rDepartment.Text = login.Teachers.Departments.Department;
                    rTitle.Text = login.Teachers.Titles.Title;
                    rBet.Text = login.Teachers.Bet.ToString();
                    imgUser.Source = new BitmapImage(new Uri(login.Teachers.PhotoPath, UriKind.Relative));
                    break;
                case 2:
                    txtSpecialization.Visibility = Visibility.Visible;
                    txtKurs.Visibility = Visibility.Visible;
                    txtForm.Visibility = Visibility.Visible;
                    txtGroup.Visibility = Visibility.Visible;

                    txtSurname.Text = login.Students.Surname;
                    txtName.Text = login.Students.NameStudent;
                    txtPatronymic.Text = login.Students.Patronymic;
                    txtBirthday.Text = login.Students.Birthday.ToString("dd.MM.yyyy");
                    txtGender.Text = login.Students.Genders.Gender;
                    rSpecialization.Text = login.Students.Specializations.Specialization;
                    rKurs.Text = login.Students.Kurses.Kurs.ToString();
                    rForm.Text = login.Students.FormOfTrainings.FormOfTraining;
                    rGroup.Text = login.Students.Groups.NameGroup;
                    imgUser.Source = new BitmapImage(new Uri(login.Students.PhotoPath, UriKind.Relative));
                    break;
            }
        }

        private void btnUpdateData_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataWindow updateData = new UpdateDataWindow(log);
            updateData.ShowDialog();
            FrameClass.frmLoad.Navigate(new UserPage(log));
        }

        private void btnUpdateLogin_Click(object sender, RoutedEventArgs e)
        {
            UpdateLoginWindow updateLogin = new UpdateLoginWindow(log);
            updateLogin.ShowDialog();
            FrameClass.frmLoad.Navigate(new UserPage(log));
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
