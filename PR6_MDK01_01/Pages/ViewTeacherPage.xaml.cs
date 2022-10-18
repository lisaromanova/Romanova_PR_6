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
    /// Логика взаимодействия для ViewTeacherPage.xaml
    /// </summary>
    public partial class ViewTeacherPage : Page
    {
        List<Teachers> lstTeacher = DataBaseClass.connect.Teachers.ToList();
        List<Teachers> list;
        public ViewTeacherPage()
        {
            InitializeComponent();
            dgTeachers.ItemsSource = lstTeacher;
        }
        private void btnAsc_Click(object sender, RoutedEventArgs e)
        {
            list = lstTeacher.OrderBy(x => x.Surname).ToList();
            dgTeachers.ItemsSource = list;
        }

        private void btnDesc_Click(object sender, RoutedEventArgs e)
        {
            list = lstTeacher.OrderByDescending(x => x.Surname).ToList();
            dgTeachers.ItemsSource = list;
        }

        private void cbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbGender.SelectedIndex)
            {
                case 0:
                    list = lstTeacher.Where(x => x.IdGender == 1).ToList();
                    break;
                case 1:
                    list = lstTeacher.Where(x => x.IdGender == 2).ToList();
                    break;
            }
            dgTeachers.ItemsSource = list;
        }

        private void cbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        void Search()
        {
            if (cbSearch.SelectedIndex != -1)
            {
                switch (cbSearch.SelectedIndex)
                {
                    case 0:
                        list = lstTeacher.Where(x => x.Surname.Contains(txtSearch.Text)).ToList(); break;
                    case 1:
                        list = lstTeacher.Where(x => x.NameTeacher.Contains(txtSearch.Text)).ToList(); break;
                }
                dgTeachers.ItemsSource = list;
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cbSearch.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            txtSearch.Text = "";
            dgTeachers.ItemsSource = lstTeacher;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmLoad.Navigate(new AdminPage());
        }
    }
}
