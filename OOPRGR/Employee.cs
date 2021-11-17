using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Employee : IPerson
    {
        private string _fullName;
        private string _diplomNumber;
        private string _position;
        private uint _salary;

        public Employee(string fullName, string diplomNumber, string position, uint salary)
        {
            _fullName = fullName;
            _diplomNumber = diplomNumber;
            _position = position;
            _salary = salary;
        }

        public string Name
        {
            get { return _fullName; }
        }
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public uint Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public string DiplomInfo
        {
            get { return _diplomNumber; }
        }
        public void Enter()
        {
            Console.WriteLine("Работник " + Name + " зашел в библиотеку.");
        }

        public void Leave()
        {
            Console.WriteLine("Работник " + Name + " вышел из библиотеки.");
        }

        public virtual void Action()
        {
            Console.WriteLine("Работник " + Name + " приступил к работе.");
        }

        public void Walk()
        {
            Console.WriteLine("Работник " + Name + " ходит по библиотеке.");
        }

        public void EndJob()
        {
            Console.WriteLine("Работник " + Name + " закончил работу.");
        }

    }
}
