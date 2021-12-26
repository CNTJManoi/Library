using System;
using System.Collections.Generic;

namespace OOPRGR
{
    class Visitor : IPerson
    {
        #region Поля
        private string _fullName;
        private uint _seriesPassport;
        private uint _numberPassport;
        private string _address;
        private ulong _phoneNumber;
        private ulong _readerTicketNumber;
        private List<Book> _listBooks;
        private List<Journal> _listJournal;
        private bool _inLibrary;
        #endregion

        #region Конструктор
        /// <summary>
        /// Создание посетителя
        /// </summary>
        /// <param name="fullName">Полное имя</param>
        /// <param name="seriesPassport">Серия паспорта</param>
        /// <param name="numberPassport">Номер паспорта</param>
        /// <param name="address">Адрес жительства</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="readetTicketNumber">Номер читательского билета</param>
        public Visitor(string fullName, uint seriesPassport,uint  numberPassport, string address, ulong phoneNumber, ulong readetTicketNumber)
        {
            _fullName = fullName;
            _seriesPassport = seriesPassport;
            _numberPassport = numberPassport;
            _address = address;
            _phoneNumber = phoneNumber;
            _readerTicketNumber = readetTicketNumber;
            _listBooks = new List<Book>();
            _listJournal = new List<Journal>();
            _inLibrary = false;
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Возвращает имя посетителя
        /// </summary>
        public string Name
        {
            get { return _fullName; }
        }
        /// <summary>
        /// Возвращает состояние посетителя. True - в библиотеке, False - не в библиотеке
        /// </summary>
        public bool InLibrary
        {
            get { return _inLibrary; }
        }
        /// <summary>
        /// Возвращает серию паспорта
        /// </summary>
        public uint SeriesPassport
        {
            get { return _seriesPassport; }
            set { _seriesPassport = value; }
        }
        /// <summary>
        /// Возвращает номер паспорта
        /// </summary>
        public uint NumberPassport
        {
            get { return _numberPassport; }
            set { _numberPassport = value; }
        }
        /// <summary>
        /// Возвращает адрес жительства посетителя
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// Возвраает номер телефона посетителя
        /// </summary>
        public ulong PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        /// <summary>
        /// Возвращает номер читательского билета посетителя
        /// </summary>
        public ulong ReaderTicketNumber
        {
            get { return _readerTicketNumber; }
        }

        #endregion

        #region Реализация интерфейса
        public void Enter()
        {
            if (!_inLibrary)
            {
                _inLibrary = true;
                Console.WriteLine("Посетитель " + _fullName + " зашел в библиотеку.");
                
            }
            else
            {
                Console.WriteLine("Посетитель " + _fullName + " уже в библиотеке!");
            }
        }

        public void Leave()
        {
            if (_inLibrary)
            {
                _inLibrary = false;
                Console.WriteLine("Посетитель " + _fullName + " вышел из библиотеки.");
            }
            else
            {
                Console.WriteLine("Посетитель " + _fullName + " находится не в библиотеке!");
            }
        }

        public void Action()
        {
            if (_inLibrary)
            {

            }
            else
            {
                Console.WriteLine("Посетитель находится не в библиотеке.");
            }
        }
        public void Walk()
        {
            if (_inLibrary)
            {
                Console.WriteLine("Посетитель " + _fullName + " ходит по библиотеке!");
            }
            else
            {
                Console.WriteLine("Посетитель " + _fullName + " находится не в библиотеке!");
            }
        }

        #endregion

        #region Методы
        /// <summary>
        /// Взять книгу
        /// </summary>
        /// <param name="b">Экземпляр книги</param>
        public void TakeBook(Book b)
        {
            _listBooks.Add(b);
        }
        /// <summary>
        /// Взять журнал
        /// </summary>
        /// <param name="b">Экземпляр журнала</param>
        public void TakeJournal(Journal b)
        {
            _listJournal.Add(b);
        }
        #endregion
    }
}
