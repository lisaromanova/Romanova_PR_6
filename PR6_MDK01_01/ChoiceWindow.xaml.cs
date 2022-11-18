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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace PR6_MDK01_01
{
    /// <summary>
    /// Логика взаимодействия для ChoiceWindow.xaml
    /// </summary>
    public partial class ChoiceWindow : Window
    {
        List<Photos> listPhotos;
        Photos main;
        Logined log;
        public ChoiceWindow(List<Photos> listPhotos, Photos main, Logined log)
        {
            InitializeComponent();
            this.listPhotos = listPhotos;
            this.main = main;
            this.log = log;
        }

        private void btnAddNewPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if ((bool)OFD.ShowDialog())
            {
                try
                {
                    Photos photo = new Photos();
                    photo.IdUser = log.IdUser;
                    System.Drawing.Image SDI = System.Drawing.Image.FromFile(OFD.FileName);
                    ImageConverter IC = new ImageConverter();
                    byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                    photo.PhotoBinary = Barray;
                    if (main != null)
                    {
                        main.MainPhoto = null;
                    }
                    photo.MainPhoto = true;
                    DataBaseClass.connect.Photos.Add(photo);
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Фото добавлено!", "Добавление фото", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Добавление фото", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private void btnChooseFromGallery_Click(object sender, RoutedEventArgs e)
        {
            GalleryWindow gallery = new GalleryWindow(listPhotos, main);
            this.Hide();
            gallery.ShowDialog();
            this.Close();
        }
    }
}
