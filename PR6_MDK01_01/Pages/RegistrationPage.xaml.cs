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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            cbDepartmnet.ItemsSource = DataBaseClass.connect.Departments.ToList();
            cbDepartmnet.SelectedValuePath = "IdDepartment";
            cbDepartmnet.DisplayMemberPath = "Department";
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
        }

        static bool IsClear(string surname, string name, string patronymic, string date, bool man, bool woman, string login, string pasword)
        {
            if (surname != "")
            {
                if (name != "")
                {
                    if (patronymic != "")
                    {
                        if (date != "")
                        {
                            if (man || woman)
                            {
                                if (login != "")
                                {
                                    if (pasword != "")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Заполните поле Пароль", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Заполните поле Логин", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Выберите пол", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите дату рождения", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле Отчество", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле Имя", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        static bool IsClearTeacher(int department)
        {
            if(department != -1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Выберите кафедру из списка", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        static bool IsClearStudent(int spec, int kurs, int form, int group)
        {
            if (spec != -1)
            {
                if (kurs != -1)
                {
                    if (form != -1)
                    {
                        if (group != -1)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Выберите группу из списка", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите форму обучения из списка", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите курс из списка", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Выберите специальность из списка", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void rbStudent_Checked(object sender, RoutedEventArgs e)
        {
            CommonData.Visibility = Visibility.Visible;
            TeacherData.Visibility = Visibility.Collapsed;
            StudentData.Visibility = Visibility.Visible;
            Logined.Visibility = Visibility.Visible;
            btnReg.Visibility = Visibility.Visible;
        }


        private void rbTeacher_Checked(object sender, RoutedEventArgs e)
        {
            CommonData.Visibility = Visibility.Visible;
            StudentData.Visibility = Visibility.Collapsed;
            TeacherData.Visibility = Visibility.Visible;
            Logined.Visibility = Visibility.Visible;
            btnReg.Visibility = Visibility.Visible;
        }

        bool LoginCheck(string login)
        {
            Logined log = DataBaseClass.connect.Logined.FirstOrDefault(x => x.LoginUser == login);
            if(log == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Логин занят!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        bool PasswordCheck(string password)
        {
            Regex r = new Regex("\\d");
            if(r.Matches(password).Count >= 2)
            {
                r = new Regex("[A-Z]");
                if(r.Matches(password).Count >= 1)
                {
                    r = new Regex("[a-z]");
                    if (r.Matches(password).Count >= 3)
                    {
                        r = new Regex("[!@#$%^&*()]");
                        if (r.Matches(password).Count >= 1)
                        {
                            if (password.Length >= 8)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Длина пароля должна быть не менее 8 символов!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("В пароле должно быть не менее одного специального символа!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("В пароле должно быть не менее трех строчных латинских символов!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;

                    }
                }
                else
                {
                    MessageBox.Show("В пароле должно быть не менее одно заглавного латинского символа!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;

                }
            }
            else
            {
                MessageBox.Show("В пароле должно быть не менее двух цифр!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (IsClear(tbSurname.Text, tbName.Text, tbPatronymic.Text, dtBirthday.Text, (bool)rbMan.IsChecked, (bool)rbWoman.IsChecked, tbLogin.Text, pswPassword.Password))
            {
                if (LoginCheck(tbLogin.Text))
                {
                    if (PasswordCheck(pswPassword.Password))
                    {
                        //int gender = 0;
                        //if (rbMan.IsChecked == true)
                        //{
                        //    gender = 1;
                        //}
                        //else
                        //{
                        //    gender = 2;
                        //}

                        //if (rbStudent.IsChecked == true)
                        //{
                        //    if (IsClearStudent(cbDepartmnet.SelectedIndex, cbKurs.SelectedIndex, cbFormOfTraining.SelectedIndex, cbGroup.SelectedIndex))
                        //    {
                        //        Logined log = new Logined()
                        //        {
                        //            LoginUser = tbLogin.Text,
                        //            PasswordUser = pswPassword.Password.GetHashCode(),
                        //            IdRole = 2
                        //        };
                        //        DataBaseClass.connect.Logined.Add(log);
                        //        DataBaseClass.connect.SaveChanges();
                        //        Students student = new Students()
                        //        {
                        //            IdStudent = log.IdUser,
                        //            Surname = tbSurname.Text,
                        //            NameStudent = tbName.Text,
                        //            Patronymic = tbPatronymic.Text,
                        //            Birthday = (DateTime)dtBirthday.SelectedDate,
                        //            IdGender = gender,
                        //            IdSpecialization = (int)cbSpecialization.SelectedValue,
                        //            IdKurs = (int)cbKurs.SelectedValue,
                        //            IdFormOfTraining = (int)cbFormOfTraining.SelectedValue,
                        //            IdGroup = (int)cbGroup.SelectedValue,
                        //        };

                        //        DataBaseClass.connect.Students.Add(student);
                        //        DataBaseClass.connect.SaveChanges();
                        //        MessageBox.Show("Успешная регистрация!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                        //    }
                        //}
                        //else
                        //{
                        //    if (IsClearTeacher(cbDepartmnet.SelectedIndex))
                        //    {
                        //        Logined log = new Logined()
                        //        {
                        //            LoginUser = tbLogin.Text,
                        //            PasswordUser = pswPassword.Password.GetHashCode(),
                        //            IdRole = 3
                        //        };
                        //        DataBaseClass.connect.Logined.Add(log);
                        //        DataBaseClass.connect.SaveChanges();
                        //        Teachers teacher = new Teachers()
                        //        {
                        //            IdTeacher = log.IdUser,
                        //            Surname = tbSurname.Text,
                        //            NameTeacher = tbName.Text,
                        //            Patronymic = tbPatronymic.Text,
                        //            Birthday = (DateTime)dtBirthday.SelectedDate,
                        //            IdGender = gender,
                        //            IdDepartment = (int)cbDepartmnet.SelectedValue
                        //        };
                        //        DataBaseClass.connect.Teachers.Add(teacher);
                        //        DataBaseClass.connect.SaveChanges();
                        //        MessageBox.Show("Успешная регистрация!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                        //    }
                        //}
                    }
                }
            }
        }
    }
}
