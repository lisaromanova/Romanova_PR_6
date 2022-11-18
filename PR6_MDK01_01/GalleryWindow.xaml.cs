using PR6_MDK01_01.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PR6_MDK01_01
{
    /// <summary>
    /// Логика взаимодействия для GalleryWindow.xaml
    /// </summary>
    public partial class GalleryWindow : Window
    {
        List<Photos> list;
        Photos mainPhoto;
        int n = 0;

        public GalleryWindow(List<Photos> list, Photos mainPhoto)
        {
            InitializeComponent();
            this.list = list;
            this.mainPhoto = mainPhoto;
            if (list.Count!=0)
            {
                byte[] Bar = list[n].PhotoBinary;
                showImage(Bar, imgGallery);
            }
        }

        void showImage(byte[] Barray, Image img)
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            n--;
            if (n == -1)
            {
                n = list.Count-1;
            }
            byte[] Bar = list[n].PhotoBinary;
            showImage(Bar, imgGallery);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            n++;
            if (n == list.Count)
            {
                n = 0;
            }
            byte[] Bar = list[n].PhotoBinary;
            showImage(Bar, imgGallery);
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (mainPhoto != null)
            {
                mainPhoto.MainPhoto = null;
            }
            Photos photoNew = list[n];
            photoNew.MainPhoto = true;
            DataBaseClass.connect.SaveChanges();
            MessageBox.Show("Фото изменено!", "Изменение фото", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
