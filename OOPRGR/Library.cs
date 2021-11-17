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
        public Catalog GetCatalog { get { return _catalog; } }
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
        public void GetListEmployees()
        {
            Console.WriteLine("В данный момент в библиотеке работают: ");
            foreach (var emp in _employees)
            {
                Console.WriteLine(emp.Position + ": " + emp.Name + " с зарплатой " + emp.Salary);
            }
        }
        public void GetBooksList()
        {
            Console.WriteLine("Список книг в библиотеке: ");
            int i = 1;
            foreach (var book in _catalog.GetCatalog)
            {
                Console.WriteLine(i.ToString() + ": " + book.GetName + "/" + book.GetAuthor + "/" + book.GetPublication +
                    "/" + book.GetNumberPages + "/" + book.GetISBN + " находится " + book.GetLocation + " в количестве " + book.GetCount);
                i++;
            }
        }
        public void GetVisitors()
        {
            Console.WriteLine("Посетители в библиотеке: ");
            foreach (var vs in _visitors)
            {
                Console.WriteLine(vs.Name + ". Номер читательского билета: " + vs.ReaderTicketNumber);
            }
        }
        public void AddVisitor(Visitor vs)
        {
            _visitors.Add(vs);
        }
        public void AddEmployee(Employee emp)
        {
            _employees.Add(emp);
        }
    }
}
