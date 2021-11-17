using System;

namespace OOPRGR
{
    class Cleaner : Employee
    {
        #region Конструктор
        public Cleaner(string fullName, string diplomNumber, uint salary) : base(fullName, diplomNumber, "Уборщик", salary)
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
