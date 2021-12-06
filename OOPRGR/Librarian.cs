using System;

namespace OOPRGR
{
    class Librarian : Employee
    {
        #region Конструктор
        /// <summary>
        /// Создание библиотекаря
        /// </summary>
        /// <param name="fullName">Полное имя</param>
        /// <param name="diplomNumber">Номер диплома</param>
        /// <param name="salary">Зарплата</param>
        public Librarian(string fullName, string diplomNumber, uint salary) : base(fullName, diplomNumber, "Библиотекарь", salary)
        {
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод осуществляет одно действие библиотекаря
        /// </summary>
        public override void DoOneJob()
        {
            Console.WriteLine("Библиотекарь " + Name + " расставляет книги и журналы");
        }
        #endregion
    }
}
