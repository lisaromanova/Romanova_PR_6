﻿using System;
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
                if (Photo == null)
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
                    return Photo;
                }
            }
        }

        public string LessonsTeacher
        {
            get
            {
                List<Lessons> ls = DataBaseClass.connect.Lessons.Where(x=> x.IdTeacher==IdTeacher).ToList();
                string str="Проведенные занятия:\n";
                if(ls.Count==0)
                {
                    str+= "Нет проведенных занятий\n";
                }
                else
                {
                    foreach (Lessons l in ls)
                    {
                        str += l.DateLesson.ToString("dd.MM") + " " + l.Groups.NameGroup + " " + l.Disciplines.Discipline + "\n";
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
