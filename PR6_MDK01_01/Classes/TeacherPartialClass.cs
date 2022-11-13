using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
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

        public string PhotoPath
        {
            get
            {
                List<Photos> photo = DataBaseClass.connect.Photos.Where(x=> x.IdUser==Logined.IdUser).ToList();
                if (photo.Count == 0)
                {
                    if (IdGender == 1)
                    {
                        return "\\Resources\\TeacherMan.png";
                    }
                    else
                    {
                        return "\\Resources\\Teacher.png";
                    }

                }
                else
                {
                    return photo[0].PhotoPath;
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
