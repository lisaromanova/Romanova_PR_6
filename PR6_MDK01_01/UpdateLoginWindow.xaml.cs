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

namespace PR6_MDK01_01
{
    /// <summary>
    /// Логика взаимодействия для UpdateLoginWindow.xaml
    /// </summary>
    public partial class UpdateLoginWindow : Window
    {
        Logined log;
        public UpdateLoginWindow(Logined log)
        {
            InitializeComponent();
            this.log = log;
            tbLogin.Text = log.LoginUser;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        bool LoginCheck(string login)
        {
            if (Regex.IsMatch(login, "^[a-z]{3,}$"))
            {
                Logined log = DataBaseClass.connect.Logined.FirstOrDefault(x => x.LoginUser == login);
                if (log == null)
                {
                    return true;
                }
                else
                {
                    if (log.IdUser == this.log.IdUser)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Логин занят!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите Логин корректно", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
        }

        bool PasswordCheck(string password)
        {
            if (Regex.Matches(password, "\\d").Count >= 2)
            {
                if (Regex.Matches(password, "[A-Z]").Count >= 1)
                {
                    if (Regex.Matches(password, "[a-z]").Count >= 3)
                    {
                        if (Regex.Matches(password, "[!@#$%^&*()]").Count >= 1)
                        {
                            if (password.Length >= 8)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Длина пароля должна быть не менее 8 символов!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("В пароле должно быть не менее одного специального символа!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("В пароле должно быть не менее трех строчных латинских символов!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;

                    }
                }
                else
                {
                    MessageBox.Show("В пароле должно быть не менее одно заглавного латинского символа!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;

                }
            }
            else
            {
                MessageBox.Show("В пароле должно быть не менее двух цифр!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        bool RepeatePassword(string password, string rpassword)
        {
            if (password == rpassword)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        bool OldPasswordCheck(string password)
        {
            if (password.GetHashCode() == log.PasswordUser)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Старый пароль введен неверно!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void btnUpdateData_Click(object sender, RoutedEventArgs e)
        {
            if (LoginCheck(tbLogin.Text))
            {
                if (OldPasswordCheck(pswOldPassword.Password))
                {
                    if (PasswordCheck(pswNewPassword.Password))
                    {
                        if(RepeatePassword(pswNewPassword.Password, pswRepeatePassword.Password))
                        {
                            log.LoginUser = tbLogin.Text;
                            log.PasswordUser = pswNewPassword.Password.GetHashCode();
                            MessageBox.Show("Данные успешно изменены!", "Изменение данных для входа", MessageBoxButton.OK, MessageBoxImage.Information);
                            DataBaseClass.connect.SaveChanges();
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
