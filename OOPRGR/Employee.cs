using System;

namespace OOPRGR
{
    public abstract class Employee : IPerson
    {
        #region Поля
        private string _fullName;
        private string _diplomNumber;
        private string _position;
        private uint _salary;
        private bool _inLibrary;
        private bool _doJob;
        #endregion

        #region Конструктор
        /// <summary>
        /// Абстрактный класс описывающий рабочего в библиотеке
        /// </summary>
        /// <param name="fullName">Полное имя</param>
        /// <param name="diplomNumber">Номер диплома</param>
        /// <param name="position">Должность</param>
        /// <param name="salary">ЗАрплата</param>
        public Employee(string fullName, string diplomNumber, string position, uint salary)
        {
            _fullName = fullName;
            _diplomNumber = diplomNumber;
            _position = position;
            _salary = salary;
            _inLibrary = false;
            _doJob = false;
        }
        #endregion

        #region Свойства
        public string Name
        {
            get { return _fullName; }
        }
        public bool InLibrary
        {
            get { return _inLibrary; }
            private set { _inLibrary = value; }
        }
        public bool DoJob
        {
            get { return _doJob; }
            private set { _doJob = value; }
        }
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public uint Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public string DiplomInfo
        {
            get { return _diplomNumber; }
        }
        #endregion

        #region Реализация интерфейса
        public void Enter()
        {
            if (!InLibrary)
            {
                Console.WriteLine("Работник " + Name + " зашел в библиотеку.");
                InLibrary = true;
            }
            else
            {
                Console.WriteLine("Работник " + Name + " уже в библиотеке.");
            }
        }

        public void Leave()
        {
            if (InLibrary)
            {
                Console.WriteLine("Работник " + Name + " вышел из библиотеки.");
                InLibrary = false;
            }
            else
            {
                Console.WriteLine("Работник " + Name + " не в библиотеке.");
            }
        }

        public virtual void Action()
        {
            if (DoJob)
            {
                EndJob();
            }
            else
            {
                StartJob();
            }
        }

        public void Walk()
        {
            if (InLibrary)
            {
                Console.WriteLine("Работник " + Name + " ходит по библиотеке.");
            }
            else
            {
                Console.WriteLine("Работник " + Name + " не в библиотеке.");
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Начать работу
        /// </summary>
        public void StartJob()
        {
            if (!DoJob)
            {
                Console.WriteLine("Работник " + Name + " приступил к работе.");
                DoJob = true;
            }
            else
            {
                Console.WriteLine("Работник " + Name + " и так работает.");
            }
        }
        /// <summary>
        /// Прекратить работу
        /// </summary>
        public void EndJob()
        {
            if (DoJob)
            {
                Console.WriteLine("Работник " + Name + " заканчивает работать.");
                DoJob = false;
            }
            else
            {
                Console.WriteLine("Работник " + Name + " уже не работает.");
            }
        }
        /// <summary>
        /// Осуществить одно рабочее действие
        /// </summary>
        public virtual void DoOneJob()
        {
            Console.WriteLine("Рабочий " + Name + " совершает одно рабочее действие.");
        }
        #endregion
    }
}
