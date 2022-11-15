using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public string PhotoPath
        {
            get
            {
                List<Photos> photo = DataBaseClass.connect.Photos.Where(x => x.IdUser == Logined.IdUser).ToList();
                if (photo.Count == 0)
                {
                     return "\\Resources\\Student.png";
                }
                else
                {
                    return photo[0].PhotoPath;
                }
            }
        }
    }
}
