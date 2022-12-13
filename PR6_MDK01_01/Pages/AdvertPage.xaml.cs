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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR6_MDK01_01.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdvertPage.xaml
    /// </summary>
    public partial class AdvertPage : Page
    {
        public AdvertPage()
        {
            InitializeComponent();
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = 35;
            animation.From = 30;
            animation.Duration = TimeSpan.FromSeconds(5);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.AutoReverse = true;
            tbHeader.BeginAnimation(FontSizeProperty, animation);

            Color color1 = Color.FromRgb(34, 0, 200);
            Color color2 = Color.FromRgb(39, 87, 141);

            ColorAnimation background = new ColorAnimation();
            background.From = color2;
            background.To = color1;
            background.Duration = TimeSpan.FromSeconds(4);
            background.RepeatBehavior = RepeatBehavior.Forever;
            background.AutoReverse = true;
            btnSignUp.Background.BeginAnimation(SolidColorBrush.ColorProperty, background);

            DoubleAnimation width = new DoubleAnimation();
            width.To = 270;
            width.From = 220;
            width.Duration = TimeSpan.FromSeconds(4);
            width.RepeatBehavior = RepeatBehavior.Forever;
            width.AutoReverse = true;
            btnSignUp.BeginAnimation(WidthProperty, width);

            DoubleAnimation height = new DoubleAnimation();
            height.To = 65;
            height.From = 60;
            height.Duration = TimeSpan.FromSeconds(4);
            height.RepeatBehavior = RepeatBehavior.Forever;
            height.AutoReverse = true;
            btnSignUp.BeginAnimation(HeightProperty, height);

            DoubleAnimation widthImage = new DoubleAnimation();
            widthImage.To = 430;
            widthImage.From = 380;
            widthImage.Duration = TimeSpan.FromSeconds(3);
            widthImage.RepeatBehavior = RepeatBehavior.Forever;
            widthImage.AutoReverse = true;
            image.BeginAnimation(WidthProperty, widthImage);

            DoubleAnimation heightImage = new DoubleAnimation();
            heightImage.To = 530;
            heightImage.From = 480;
            heightImage.Duration = TimeSpan.FromSeconds(4);
            heightImage.RepeatBehavior = RepeatBehavior.Forever;
            heightImage.AutoReverse = true;
            image.BeginAnimation(HeightProperty, heightImage);

            ThicknessAnimation MA = new ThicknessAnimation();
            MA.To = new Thickness(30, 30, 30, 30);
            MA.From = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(4);
            MA.AutoReverse = true;
            MA.RepeatBehavior = RepeatBehavior.Forever;
            MA.AutoReverse = true;
            btnSignUp.BeginAnimation(MarginProperty, MA);

        }
    }
}