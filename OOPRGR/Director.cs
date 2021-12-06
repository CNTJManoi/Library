using System;

namespace OOPRGR
{
    class Director : Employee
    {
        #region Конструктор
        /// <summary>
        /// Создает директора
        /// </summary>
        /// <param name="fullName">Полное имя</param>
        /// <param name="diplomNumber">Номер диплома</param>
        /// <param name="salary">Зарплата</param>
        public Director(string fullName, string diplomNumber, uint salary) : base(fullName, diplomNumber, "Директор", salary) { }
        #endregion

        #region Методы
        /// <summary>
        /// Метод позволяет выполнить одно действие директора
        /// </summary>
        public override void DoOneJob()
        {
            Console.WriteLine("Директор " + Name + " приказывает другим работать");
        }
        #endregion
    }
}
