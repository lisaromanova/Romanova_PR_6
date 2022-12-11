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
            animation.To = 40;
            animation.From = 30;
            animation.Duration = TimeSpan.FromSeconds(3);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.AutoReverse = true;
            tbHeader.BeginAnimation(FontSizeProperty, animation);

            //ColorAnimation colorAnimation = new ColorAnimation();
            Color color1 = Color.FromRgb(255, 255, 255);
            Color color2 = Color.FromRgb(39, 87, 141);
            Color color3 = Color.FromRgb(0, 0, 0);
            //colorAnimation.From = color3;
            //colorAnimation.To = color2;
            //colorAnimation.Duration = TimeSpan.FromSeconds(3);
            //colorAnimation.RepeatBehavior = RepeatBehavior.Forever;
            //colorAnimation.AutoReverse = true;
            //btnSignUp.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            ColorAnimation background = new ColorAnimation();
            background.From = color2;
            background.To = color1;
            background.Duration = TimeSpan.FromSeconds(3);
            background.RepeatBehavior = RepeatBehavior.Forever;
            background.AutoReverse = true;
            btnSignUp.Background.BeginAnimation(SolidColorBrush.ColorProperty, background);

            //ColorAnimation foreground = new ColorAnimation();
            //foreground.From = color1;
            //foreground.To = color3;
            //foreground.Duration = TimeSpan.FromSeconds(3);
            //foreground.RepeatBehavior = RepeatBehavior.Forever;
            //foreground.AutoReverse = true;
            //btnSignUp.BeginAnimation(ForegroundProperty, foreground);

            DoubleAnimation width = new DoubleAnimation();
            width.To = 240;
            width.From = 200;
            width.Duration = TimeSpan.FromSeconds(3);
            width.RepeatBehavior = RepeatBehavior.Forever;
            width.AutoReverse = true;
            btnSignUp.BeginAnimation(WidthProperty, width);

            DoubleAnimation height = new DoubleAnimation();
            height.To = 55;
            height.From = 45;
            height.Duration = TimeSpan.FromSeconds(3);
            height.RepeatBehavior = RepeatBehavior.Forever;
            height.AutoReverse = true;
            btnSignUp.BeginAnimation (HeightProperty, height);
        }
    }
}
