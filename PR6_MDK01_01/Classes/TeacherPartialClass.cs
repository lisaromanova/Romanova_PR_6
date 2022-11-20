using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PR6_MDK01_01.Classes;

namespace PR6_MDK01_01
{
    public partial class Teachers
    {
        public string Fio
        {
            get
            {
                return Surname + " " + NameTeacher + " " + Patronymic+", "+Titles.Title.ToLower();
            }
        }
        public string FioNew
        {
            get
            {
                return Surname + " " + NameTeacher + " " + Patronymic;
            }
        }
        public string ShortName
        {
            get
            {
                return Surname + " " + NameTeacher[0] + ". " + Patronymic[0]+".";
            }
        }

        public SolidColorBrush GenderColor
        {
            get
            {
                switch (IdTitle)
                {
                    case 1:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE5FCFF");
                    case 2:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFF7EAFF");
                    case 3:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFBEA");
                    case 4:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFEEFFEA");
                    default:
                        return Brushes.White;
                }
            }
        }

        public ImageSource PhotoPath
        {
            get
            {
                Photos mainPhoto = DataBaseClass.connect.Photos.FirstOrDefault(x => x.IdUser == IdTeacher && x.MainPhoto == true);
                if(mainPhoto == null)
                {
                    if (IdGender == 1)
                    {
                        return new BitmapImage(new Uri("\\Resources\\TeacherMan.png", UriKind.Relative)); 
                    }
                    else
                    {
                        return new BitmapImage(new Uri("\\Resources\\Teacher.png", UriKind.Relative));
                    }
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

        public string LessonsTeacher
        {
            get
            {
                List<StudyPlan> ls = DataBaseClass.connect.StudyPlan.Where(x=> x.IdTeacher==IdTeacher).ToList();
                ls = ls.OrderBy(x => x.Groups.NameGroup).ToList();
                string str="Занятость преподавателя:\n";
                if(ls.Count==0)
                {
                    str+= "Нет занятости преподавателя\n";
                }
                else
                {
                    foreach (StudyPlan l in ls)
                    {
                        str += l.Groups.NameGroup + " " + l.Disciplines.Discipline + "\n";
                    }
                }
                
                str = str.Substring(0, str.Length - 1);
                return str;
            }
        }

        public double Salary
        {
            get
            {
                double sum = 1;
                sum *= Bet * Titles.Cost;
                return sum;
            }
        }

    }
}
