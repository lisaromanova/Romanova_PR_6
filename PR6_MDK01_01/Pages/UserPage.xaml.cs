using Microsoft.Win32;
using PR6_MDK01_01.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        List<Photos> photos;
        Logined log;
        Photos mainPhoto;
        public UserPage(Logined login)
        {
            InitializeComponent();
            log = login;
            photos = DataBaseClass.connect.Photos.Where(x => x.IdUser == log.IdUser).ToList();
            mainPhoto = photos.FirstOrDefault(x => x.MainPhoto == true);
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
                    if (mainPhoto==null)
                    {
                        imgUser.Source = new BitmapImage(new Uri(login.Teachers.PhotoPath, UriKind.Relative));
                    }
                    else
                    {
                        byte[] Bar = mainPhoto.PhotoBinary;
                        showImage(Bar, imgUser);
                    }
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
                    if (mainPhoto == null)
                    {
                        imgUser.Source = new BitmapImage(new Uri("\\Resources\\Student.png", UriKind.Relative));
                    }
                    else
                    {
                        byte[] Bar = mainPhoto.PhotoBinary;
                        showImage(Bar, imgUser);
                    }
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

        void showImage(byte[] Barray, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();
            using (MemoryStream m = new MemoryStream(Barray))
            {
                BI.BeginInit();
                BI.StreamSource = m;
                BI.CacheOption = BitmapCacheOption.OnLoad;
                BI.EndInit();
            }
            img.Source = BI;
            img.Stretch = Stretch.Uniform;
        }

        void AddPhoto(string path)
        {
            Photos photo = new Photos();
            photo.IdUser = log.IdUser;
            System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
            ImageConverter IC = new ImageConverter();
            byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
            photo.PhotoBinary = Barray;
            DataBaseClass.connect.Photos.Add(photo);
            DataBaseClass.connect.SaveChanges();
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if ((bool)OFD.ShowDialog())
            {
                try
                {
                    AddPhoto(OFD.FileName);
                    MessageBox.Show("Фото добавлено!", "Добавление фото", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameClass.frmLoad.Navigate(new UserPage(log));
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Добавление фото", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAddPhotos_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = true;
            if (OFD.ShowDialog() == true)
            {
                try
                {
                    foreach (string file in OFD.FileNames)
                    {
                        AddPhoto(file);
                    }
                    MessageBox.Show("Фото добавлены!", "Добавление фото", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameClass.frmLoad.Navigate(new UserPage(log));
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Добавление фото", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnUpdatePhoto_Click(object sender, RoutedEventArgs e)
        {
            ChoiceWindow choice = new ChoiceWindow(photos, mainPhoto, log);
            choice.ShowDialog();
            FrameClass.frmLoad.Navigate(new UserPage(log));
        }
    }
}
