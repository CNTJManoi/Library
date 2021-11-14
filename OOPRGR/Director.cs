using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Director : Employee
    {
        public Director(string fullName, string diplomNumber, uint salary) : base (fullName, diplomNumber, "Директор", salary) { }
        public override void Action()
        {
            Console.WriteLine("Директор " + Name + " приступил к своим управленческим обязаностям.");
        }
    }
}
