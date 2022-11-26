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
    /// Логика взаимодействия для ViewLessonsPage.xaml
    /// </summary>
    public partial class ListViewPage : Page
    {
        Pagination pagination = new Pagination();
        List<Teachers> teachers;
        public ListViewPage()
        {
            InitializeComponent();
            teachers = DataBaseClass.connect.Teachers.ToList();
            lstView.ItemsSource = teachers;
            List<Departments> departments = DataBaseClass.connect.Departments.ToList();
            cbDepartment.Items.Add("Все кафедры");
            foreach(Departments department in departments)
            {
                cbDepartment.Items.Add(department.Department);
            }
            pagination.CountPage = teachers.Count;
            DataContext = pagination;
        }

        void Sort()
        {
            teachers = DataBaseClass.connect.Teachers.ToList();
            if (cbDepartment.SelectedIndex != 0 && cbDepartment.SelectedIndex != -1)
            {
                teachers = teachers.Where(x => x.Departments.Department == (string)cbDepartment.SelectedValue).ToList();
            }

            if (!string.IsNullOrWhiteSpace(tbFio.Text))
            {
                teachers = teachers.Where(x => x.FioNew.ToLower().Contains(tbFio.Text.ToLower())).ToList();
            }
            if ((bool)chbPhoto.IsChecked)
            {
                List<int> photos = DataBaseClass.connect.Photos.Where(x => x.MainPhoto == true).Select(x=> x.IdUser).ToList();
                teachers = teachers.Where(x => photos.Contains(x.IdTeacher)).ToList();
            }
            if ((cbSort.SelectedIndex != -1) && (cbParametr.SelectedIndex != -1))
            {
                switch (cbParametr.SelectedIndex)
                {
                    case 0:
                        if (cbSort.SelectedIndex == 0)
                        {
                            teachers = teachers.OrderBy(x => x.Surname).ToList();
                        }
                        else
                        {
                            teachers = teachers.OrderByDescending(x => x.Surname).ToList();
                        }
                        break;
                    case 1:
                        if (cbSort.SelectedIndex == 0)
                        {
                            teachers = teachers.OrderBy(x => x.Birthday).ToList();
                        }
                        else
                        {
                            teachers = teachers.OrderByDescending(x => x.Birthday).ToList();
                        }
                        break;
                    case 2:
                        if (cbSort.SelectedIndex == 0)
                        {
                            teachers = teachers.OrderBy(x => x.Bet).ToList();
                        }
                        else
                        {
                            teachers = teachers.OrderByDescending(x => x.Bet).ToList();
                        }
                        break;
                }
            }
            
            if(teachers.Count > 0)
            {
                lstView.Visibility = Visibility.Visible;
                txtEmpty.Visibility = Visibility.Collapsed;
                lstView.ItemsSource = teachers;
            }
            else
            {
                lstView.Visibility = Visibility.Collapsed;
                txtEmpty.Visibility = Visibility.Visible;
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

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }

        private void tbFio_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }

        private void chbPhoto_Checked(object sender, RoutedEventArgs e)
        {
            Sort();
        }

        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            switch (tb.Uid)
            {
                case "back":
                    pagination.CurrentPage--;
                    break;
                case "next":
                    pagination.CurrentPage++;
                    break;
                default:
                    pagination.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            lstView.ItemsSource = teachers.Skip(pagination.CurrentPage * pagination.CountPage - pagination.CountPage).Take(pagination.CountPage).ToList();
        }

        private void tbCountPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pagination.CountPage = Convert.ToInt32(tbCountPage.Text);
            }
            catch
            {
                pagination.CountPage = teachers.Count;
            }
            pagination.Countlist = teachers.Count;
            lstView.ItemsSource = teachers.Skip(0).Take(pagination.CountPage).ToList();
            pagination.CurrentPage = 1;
        }
    }
}
