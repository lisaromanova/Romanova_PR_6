using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using PR6_MDK01_01.Classes;

namespace PR6_MDK01_01
{
    public partial class Students
    {
        public string ShortName
        {
            get
            {
                return Surname + " " + NameStudent[0] + ". " + Patronymic[0] + ".";
            }
        }

        public ImageSource PhotoPath
        {
            get
            {
                Photos mainPhoto = DataBaseClass.connect.Photos.FirstOrDefault(x => x.IdUser == IdStudent && x.MainPhoto == true);
                if (mainPhoto == null)
                {
                    return new BitmapImage(new Uri("\\Resources\\Student.png", UriKind.Relative));
                }
                else
                {
                    BitmapImage BI = new BitmapImage();
                    using (MemoryStream m = new MemoryStream(mainPhoto.PhotoBinary))
                    {
                        BI.BeginInit();
                        BI.StreamSource = m;
                        BI.CacheOption = BitmapCacheOption.OnLoad;
                        BI.EndInit();
                    }
                    return BI;
                }
            }
        }
    }
}
