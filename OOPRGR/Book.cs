namespace OOPRGR
{
    class Book
    {
        #region Поля
        private string _name;
        private string _author;
        private string _publication;
        private ushort _yearPublication;
        private string _genre;
        private uint _numberPages;
        private string _ISBN;
        private string _location;
        private uint _count;
        #endregion

        #region Конструктор
        /// <summary>
        /// Создает экземпляр книги
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="author">Автор</param>
        /// <param name="publication">Издание</param>
        /// <param name="yearPublication">Год издания</param>
        /// <param name="genre">Жанр</param>
        /// <param name="numberPages">Количество страниц</param>
        /// <param name="ISBN">ISBN код</param>
        /// <param name="location">Местоположение в библиотеке</param>
        /// <param name="count">Количество экземпляров в библиотеке</param>
        public Book(string name, string author, string publication, ushort yearPublication, string genre, uint numberPages, string ISBN, string location, uint count)
        {
            _name = name;
            _author = author;
            _publication = publication;
            _yearPublication = yearPublication;
            _genre = genre;
            _numberPages = numberPages;
            _ISBN = ISBN;
            _location = location;
            _count = count;
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Возвращает наименование книги
        /// </summary>
        public string GetName { get { return _name; } }
        /// <summary>
        /// Возвращает автора книги
        /// </summary>
        public string GetAuthor { get { return _author; } }
        /// <summary>
        /// Возвращает издание выпустившее книгу
        /// </summary>
        public string GetPublication { get { return _publication; } }
        /// <summary>
        /// Возвращает год издания книги
        /// </summary>
        public ushort GetYearPublication { get { return _yearPublication; } }
        /// <summary>
        /// Возвращает жанр книги
        /// </summary>
        public string GetGenre { get { return _genre; } }
        /// <summary>
        /// Возвращает количество страниц в книге
        /// </summary>
        public uint GetNumberPages { get { return _numberPages; } }
        /// <summary>
        /// Возвращает ISBN код книги
        /// </summary>
        public string GetISBN { get { return _ISBN; } }
        /// <summary>
        /// Возвращает или задает местоположение книги в библиотеке
        /// </summary>
        public string Location { 
            get { return _location; } 
            set { _location = value; }
        }
        /// <summary>
        /// Возвращает или задает количество экземпляров книги в библиотеке
        /// </summary>
        public uint Count { 
            get { return _count; }
            set { _count = value; }
        }

        #endregion
    }
}
