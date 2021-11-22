using System;

namespace OOPRGR
{
    class Cleaner : Employee
    {
        #region Конструктор
        /// <summary>
        /// Создает уборщика
        /// </summary>
        /// <param name="fullName">Полное имя</param>
        /// <param name="diplomNumber">Номере диплома. Если отсутствует, то 0</param>
        /// <param name="salary">Зарплата</param>
        public Cleaner(string fullName, string diplomNumber = "0", uint salary) : base(fullName, diplomNumber, "Уборщик", salary)
        {
        }
        #endregion

        #region Методы
        public override void DoOneJob()
        {
            Console.WriteLine("Уборщик " + Name + " убирался в одном из отделов библиотеки");
        }
        #endregion
    }
}
