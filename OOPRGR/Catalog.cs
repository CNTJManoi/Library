using System.Collections.Generic;
using System.IO;

namespace OOPRGR
{
    public delegate void NotificationHandler(string message);
    class Catalog
    {
        #region Поля
        private List<Book> _avaliableBooks;
        private List<Journal> _avaliableJournals;
        private NotificationHandler _notificationHandler;
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
        /// <summary>
        /// Возвращает список книг в каталоге
        /// </summary>
        public List<Book> BookList { get { return _avaliableBooks; } }
        /// <summary>
        /// Возвращает список журналов в каталоге
        /// </summary>
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
            if (_notificationHandler != null) _notificationHandler("Добавлена новая книга в библиотеку");
        }
        /// <summary>
        /// Добавляет журнал в библиотеку
        /// </summary>
        /// <param name="b">Экземпляр класса журнала</param>
        public void AddJournal(Journal j)
        {
            _avaliableJournals.Add(j);
            if (_notificationHandler != null) _notificationHandler("Добавлена новая книга в библиотеку");
        }
        /// <summary>
        /// Убирает 1 экземпляр книги из библиотеки
        /// </summary>
        /// <param name="b">Экземпляр класса книги</param>
        /// <returns>True если удаление успешно, иначе False</returns>
        public bool RemoveBooks(Book b)
        {
            if (_avaliableBooks.Find(x => x.GetName == b.GetName).Count != 0)
            {
                _avaliableBooks.Find(x => x.GetName == b.GetName).Count -= 1;
                if (_notificationHandler != null) _notificationHandler("Экземпляр книги " + b.GetName + " забрали.");
                return true;
            }

            return false;
        }
        /// <summary>
        /// Убирает 1 экземпляр журнала из библиотеки
        /// </summary>
        /// <param name="b">Экземпляр класса журнала</param>
        /// <returns>True если удаление успешно, иначе False</returns>
        public bool RemoveJounal(Journal j)
        {
            if (_avaliableJournals.Find(x => x.GetName == j.GetName).Count != 0)
            {
                _avaliableJournals.Find(x => x.GetName == j.GetName).Count -= 1;
                if (_notificationHandler != null) _notificationHandler("Экземпляр журнала " + j.GetName + " забрали.");
                return true;
            }

            return false;
        }
        #endregion

        #region Делегат

        public void RegisterHandler(NotificationHandler notificationHandler)
        {
            _notificationHandler += notificationHandler;
        }

        public void UnRegisterHandler(NotificationHandler notificationHandler)
        {
            if (_notificationHandler != null) _notificationHandler -= notificationHandler;
        }
        #endregion
    }
}
