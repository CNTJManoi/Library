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
        private bool _isOpen;
        private Catalog _catalog;
        private List<Employee> _employees;
        private List<Visitor> _visitors;

        public Library(string name, string timetable, string rules, Catalog catalog)
        {
            _name = name;
            _timetable = timetable;
            _rules = rules;
            _catalog = catalog;
            _isOpen = false;
            _employees = new List<Employee>();
            _visitors = new List<Visitor>();
            
        }
        public Catalog GetCatalog { get { return _catalog; } }

        public List<Employee> Employees
        {
            get { return _employees; }
        }
        public List<Visitor> Visitors
        {
            get { return _visitors; }
        }
        public string Name
        {
            get { return _name; }
        }
        public string TimeTable
        {
            get { return _timetable; }
            set { _timetable = value; }
        }
        public string Rules
        {
            get { return _rules; }
            set { _rules = value; }
        }
        public bool OpenOrClose
        {
            get { return _isOpen; }
            set { _isOpen = value; }
        }
        public void GetListEmployees()
        {
            int i = 1;
            Console.WriteLine("В данный момент в библиотеке работают: ");
            foreach (var emp in _employees)
            {
                Console.WriteLine(i.ToString() + ": " + emp.Position + ": " + emp.Name + " с зарплатой " + emp.Salary);
            }
        }
        public void GetBooksList()
        {
            Console.WriteLine("Список книг в библиотеке: ");
            int i = 1;
            foreach (var book in _catalog.CatalogList)
            {
                Console.WriteLine(i.ToString() + ": " + book.GetName + "/" + book.GetAuthor + "/" + book.GetPublication +
                    "/" + book.GetNumberPages + "/" + book.GetISBN + " находится " + book.Location + " в количестве " + book.Count);
                i++;
            }
        }
        public void GetVisitors()
        {
            int i = 1;
            Console.WriteLine("Посетители в библиотеке: ");
            foreach (var vs in _visitors)
            {
                Console.WriteLine(i.ToString() + ": " + vs.Name + ". Номер читательского билета: " + vs.ReaderTicketNumber);
            }
        }
        public void AddVisitor(Visitor vs)
        {
            if(_isOpen) _visitors.Add(vs);
            else Console.WriteLine("Библиотека закрыта!");
        }
        public void AddEmployee(Employee emp)
        {
            _employees.Add(emp);
        }
    }
}
