using System;

namespace OOPRGR
{
    class Director : Employee
    {
        #region Конструктор
        public Director(string fullName, string diplomNumber, uint salary) : base(fullName, diplomNumber, "Директор", salary) { }
        #endregion

        #region Методы
        public override void DoOneJob()
        {
            Console.WriteLine("Директор " + Name + " приказывает другим работать");
        }
        #endregion
    }
}
