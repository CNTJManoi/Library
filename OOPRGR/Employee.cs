﻿using System;
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
        public void Enter()
        {
            Console.WriteLine("Работник " + _fullName + " зашел в библиотеку.");
        }

        public void Leave()
        {
            Console.WriteLine("Работник " + _fullName + " вышел из библиотеки.");
        }

        public virtual void Action()
        {
            Console.WriteLine("Работник " + _fullName + " приступил к работе.");
        }

        public void EndJob()
        {
            Console.WriteLine("Работник " + _fullName + " закончил работу.");
        }
    }
}