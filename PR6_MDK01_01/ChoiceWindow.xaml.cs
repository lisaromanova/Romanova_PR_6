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
using System.Windows.Shapes;

namespace PR6_MDK01_01
{
    /// <summary>
    /// Логика взаимодействия для ChoiceWindow.xaml
    /// </summary>
    public partial class ChoiceWindow : Window
    {
        public ChoiceWindow(List<Photos> listPhotos)
        {
            InitializeComponent();
        }

        private void btnAddNewPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChooseFromGallery_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
