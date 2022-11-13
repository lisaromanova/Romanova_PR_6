using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
