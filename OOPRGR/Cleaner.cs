using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Cleaner : Employee
    {
        public Cleaner(string fullName, string diplomNumber, uint salary) : base(fullName, diplomNumber, "Уборщик", salary)
        {
        }
    }
}
