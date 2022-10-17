﻿using System;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            tbLogin.Text = "admin";
            pswPassword.Password = "admin";
        }

        bool IsClear(string login, string password)
        {
            if (login != "")
            {
                if (password != "")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Заполните поле Пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Логин", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            if(IsClear(tbLogin.Text, pswPassword.Password))
            {
                int password = pswPassword.Password.GetHashCode();
                Logined log = DataBaseClass.connect.Logined.FirstOrDefault(x => x.LoginUser == tbLogin.Text && x.PasswordUser == password);
                if (log != null)
                {
                    MessageBox.Show("Успешная авторизация!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (log.IdRole)
                    {
                        case 1:
                            FrameClass.frmLoad.Navigate(new AdminPage());
                            break;
                        case 2:
                        case 3:
                            FrameClass.frmLoad.Navigate(new UserPage());
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}