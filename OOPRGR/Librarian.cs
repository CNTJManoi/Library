using System;

namespace OOPRGR
{
    class Librarian : Employee
    {
        #region Конструктор
        public Librarian(string fullName, string diplomNumber, uint salary) : base(fullName, diplomNumber, "Библиотекарь", salary)
        {
        }
        #endregion

        #region Методы
        public override void DoOneJob()
        {
            Console.WriteLine("Библиотекарь " + Name + " расставляет книги и журналы");
        }
        #endregion
    }
}
