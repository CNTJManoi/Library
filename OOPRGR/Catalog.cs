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
        /// <summary>
        /// Создает каталог содержащий всю информацию о книгах в библиотеке
        /// </summary>
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
        /// <summary>
        /// Добавляет книгу в библиотеку
        /// </summary>
        /// <param name="b">Экземпляр класса книги</param>
        public void AddBooks(Book b)
        {
            _avaliableBooks.Add(b);
        }
        /// <summary>
        /// Добавляет журнал в библиотеку
        /// </summary>
        /// <param name="b">Экземпляр класса журнала</param>
        public void AddJournal(Journal j)
        {
            _avaliableJournals.Add(j);
        }
        #endregion
    }
}
