using System;
using System.Collections;
using System.Collections.Generic;

namespace OOPRGR
{
    class Library
    {
        #region Поля
        private string _name;
        private string _timetable;
        private string _rules;
        private bool _isOpen;
        private Catalog _catalog;
        private List<Employee> _employees;
        private List<Visitor> _visitors;
        #endregion

        #region Конструктор
        /// <summary>
        /// Создание библиотеки
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="timetable">Расписание</param>
        /// <param name="rules">Список правил</param>
        /// <param name="catalog">Экземпляр класса каталога</param>
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
        #endregion

        #region Свойства
        /// <summary>
        /// Возвращает экземпляр каталога
        /// </summary>
        public Catalog GetCatalog { get { return _catalog; } }
        /// <summary>
        /// Возвращает перечисляемый список рабочих
        /// </summary>
        public List<Employee> Employees
        {
            get { return _employees; }
        }
        /// <summary>
        /// Возвращает перечисляемый список посетителей
        /// </summary>
        public List<Visitor> Visitors
        {
            get { return _visitors; }
        }
        /// <summary>
        /// Возвраает наименование библиотеки
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// Возвращает расписание работы библиотеки
        /// </summary>
        public string TimeTable
        {
            get { return _timetable; }
            set { _timetable = value; }
        }
        /// <summary>
        /// Возвращает строку правил библиотеки
        /// </summary>
        public string Rules
        {
            get { return _rules; }
            set { _rules = value; }
        }
        /// <summary>
        /// Вовзращает состояние библиотеки. True - открыта, False - закрыта
        /// </summary>
        public bool OpenOrClose
        {
            get { return _isOpen; }
            set { _isOpen = value; }
        }
        #endregion  

        #region Методы
        /// <summary>
        /// Выводит список рабочих в библиотеке
        /// </summary>
        public void ListEmployees()
        {
            int i = 1;
            Console.WriteLine("В данный момент в библиотеке работают: ");
            foreach (var emp in _employees)
            {
                Console.WriteLine(i.ToString() + ": " + emp.Position + ": " + emp.Name + " с зарплатой " + emp.Salary);
                i++;
            }
        }
        /// <summary>
        /// Выводит список книг в библиотеке
        /// </summary>
        public void BooksList()
        {
            Console.WriteLine("Список книг в библиотеке: ");
            int i = 1;
            foreach (Book book in this.GetList())
            {
                Console.WriteLine(i.ToString() + ": " + book.GetName + "/" + book.GetAuthor + "/" + book.GetPublication +
                                  "/" + book.GetNumberPages + "/" + book.GetISBN + " находится: " + book.Location + " в количестве " + book.Count);
                i++;
            }
        }
        /// <summary>
        /// Выводит список журналов в библиотеке
        /// </summary>
        public void JournalList()
        {
            Console.WriteLine("Список журналов в библиотеке: ");
            int i = 1;
            foreach (Journal book in this.GetList(1))
            {
                Console.WriteLine(i.ToString() + ": " + book.GetName + "/" + book.GetAuthor
                                  + " находится: " + book.Location + " в количестве " + book.Count);
                i++;
            }
        }
        /// <summary>
        /// Выводит список посетителей в библиотеке
        /// </summary>
        public void VisitorsList()
        {
            int i = 1;
            Console.WriteLine("Посетители в библиотеке: ");
            foreach (var vs in _visitors)
            {
                Console.WriteLine(i.ToString() + ": " + vs.Name + ". Номер читательского билета: " + vs.ReaderTicketNumber);
                i++;
            }
        }
        /// <summary>
        /// Добавляет нового посетителя в библиотеку
        /// </summary>
        /// <param name="vs">Экземпляр класса посетителя</param>
        public void AddVisitor(Visitor vs)
        {
            _visitors.Add(vs);
        }
        /// <summary>
        /// Добавляет нового рабочего в библиотеку
        /// </summary>
        /// <param name="emp">Экземпляр класса рабочего</param>
        public void AddEmployee(Employee emp)
        {
            _employees.Add(emp);
        }
        /// <summary>
        /// Возвращает перечисляемый список книг или журналов
        /// </summary>
        /// <param name="i">0 - Книга, 1 - Журнал</param>
        /// <returns>IEnumarable список книг или журналов</returns>
        public IEnumerable GetList(int i = 0)
        {
            if (i == 0)
            {
                for (int j = 0; j < _catalog.BookList.Count; j++)
                {
                    yield return _catalog.BookList[j];
                }
            }
            else
            {
                for (int j = 0; j < _catalog.JournalList.Count; j++)
                {
                    yield return _catalog.JournalList[j];
                }
            }
        }
        #endregion
    }
}
