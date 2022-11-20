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
    /// Логика взаимодействия для ViewLessonsPage.xaml
    /// </summary>
    public partial class ListViewPage : Page
    {
        public ListViewPage()
        {
            InitializeComponent();
            lstView.ItemsSource = DataBaseClass.connect.Teachers.ToList();
            List<Departments> departments = DataBaseClass.connect.Departments.ToList();
            cbDepartment.Items.Add("Все кафедры");
            foreach(Departments department in departments)
            {
                cbDepartment.Items.Add(department.Department);
            }
        }

        void Sort()
        {
            List<Teachers> teachers = new List<Teachers>();
            if (cbDepartment.SelectedIndex == 0)
            {
                teachers = DataBaseClass.connect.Teachers.ToList();
            }
            else
            {
                teachers = DataBaseClass.connect.Teachers.Where(x=> x.Departments.Department == (string)cbDepartment.SelectedValue).ToList();
            }
            if (!string.IsNullOrWhiteSpace(tbFio.Text))
            {
                teachers = teachers.Where(x => x.FioNew.Contains(tbFio.Text)).ToList();
            }
            if ((bool)chbPhoto.IsChecked)
            {
                List<Photos> photos = DataBaseClass.connect.Photos.Where(x => x.MainPhoto == true).ToList();
                
            }
            if ((cbSort.SelectedIndex != -1) && (cbParametr.SelectedIndex != -1))
            {
                
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new AdminPage());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Teachers teacher = DataBaseClass.connect.Teachers.FirstOrDefault(x=> x.IdTeacher==index);
            FrameClass.frmLoad.Navigate(new LessonsPage(teacher));
        }

        private void btnAddPlan_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new AddStudyPlanPage());
        }
    }
}
