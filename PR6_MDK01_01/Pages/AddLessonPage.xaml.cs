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
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new LessonsPage(teacher));
        }
    }
}