using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Library
    {
        private string _name;
        private string _timetable;
        private string _rules;
        private Catalog _catalog;
        private List<Employee> _employees;
        private List<Visitor> _visitors;

        public Library(string name, string timetable, string rules, Catalog catalog)
        {
            _name = name;
            _timetable = timetable;
            _rules = rules;
            _catalog = catalog;
            _employees = new List<Employee>();
            _visitors = new List<Visitor>();
        }

        public void GetListEmployees()
        {
            Console.WriteLine("В данный момент в библиотеке работают: ");
            foreach (var emp in _employees)
            {
                
            }
        }
    }
}
