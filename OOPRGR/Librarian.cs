using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Librarian : Employee
    {
        public Librarian(string fullName, string diplomNumber, uint salary) : base(fullName, diplomNumber, "Библиотекарь", salary)
        {
        }
        public override void Action()
        {
            Console.WriteLine("Библиотекарь " + Name + " приступил к своим обязаностям.");
        }
    }
}
