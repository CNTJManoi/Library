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

        }

        public void Leave()
        {
            throw new NotImplementedException();
        }

        public void Action()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Методы

        public void TakeBook()
        {

        }

        #endregion
    }
}
