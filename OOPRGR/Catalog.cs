using System.Collections.Generic;

namespace OOPRGR
{
    class Catalog
    {
        #region Поля
        private List<Book> _avaliableBooks;
        private List<Journal> _avaliableJournals;
        #endregion

        #region Конструктор
        public Catalog()
        {
            _avaliableBooks = new List<Book>();
            _avaliableJournals = new List<Journal>();
        }
        #endregion

        #region Свойства
        public List<Book> BookList { get { return _avaliableBooks; } }
        public List<Journal> JournalList { get { return _avaliableJournals; } }
        #endregion

        #region Методы
        public void AddBooks(Book b)
        {
            _avaliableBooks.Add(b);
        }

        public void AddJournal(Journal j)
        {
            _avaliableJournals.Add(j);
        }
        #endregion
    }
}
