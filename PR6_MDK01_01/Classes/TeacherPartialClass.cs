using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR6_MDK01_01.Classes;

namespace PR6_MDK01_01
{
    public partial class Teachers
    {
        public string Fio
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
                string str="";
                foreach(Lessons l in ls)
                {
                    str += l.DateLesson.ToString("dd.MM") + " " + l.Groups.NameGroup + " " + l.Disciplines.Discipline + "\n";
                }
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
