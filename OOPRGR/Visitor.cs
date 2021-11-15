using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Visitor : IPerson
    {
        #region Поля
        private string _fullName;
        private uint _seriesPassport;
        private uint _numberPassport;
        private string _address;
        private uint _phoneNumber;
        private uint _readerTicketNumber;
        private List<Book> _listBooks;
        private bool _inLibrary;
        #endregion
        #region Конструктор
        public Visitor(string fullName, uint seriesPassport,uint  numberPassport, string address, uint phoneNumber, uint readetTicketNumber)
        {
            _fullName = fullName;
            _seriesPassport = seriesPassport;
            _numberPassport = numberPassport;
            _address = address;
            _phoneNumber = phoneNumber;
            _readerTicketNumber = readetTicketNumber;
            _listBooks = new List<Book>();
            _inLibrary = false;
        }
        #endregion
        #region Свойства
        public string Name
        {
            get { return _fullName;}
            set
            {
                if (value != "") _fullName = value;
                else throw new Exception("Неверный аргумент.");
            }
        }
        public uint SeriesPassport
        {
            get { return _seriesPassport;}
            set { _seriesPassport = value; }
        }
        public uint NumberPassport {
            get { return _numberPassport; }
            set { _numberPassport = value; }
        }
        public string Address {
            get { return _address; }
            set { _address = value; }
        }
        public uint PhoneNumber {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public uint ReaderTicketNumber {
            get { return _readerTicketNumber; }
            set { _readerTicketNumber = value; }
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
                Console.WriteLine("Посетитель " + _fullName + " не был в библиотеке!");
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
        #endregion

        #region Методы

        public void TakeBook(uint id)
        {

        }

        #endregion
    }
}
