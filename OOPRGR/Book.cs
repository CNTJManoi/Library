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
        public string GetName { get { return _name; } }
        public string GetAuthor { get { return _author; } }
        public string GetPublication { get { return _publication; } }
        public ushort GetYearPublication { get { return _yearPublication; } }
        public string GetGenre { get { return _genre; } }
        public uint GetNumberPages { get { return _numberPages; } }
        public string GetISBN { get { return _ISBN; } }
        public string Location { 
            get { return _location; } 
            set { _location = value; }
        }
        public uint Count { 
            get { return _count; }
            set { _count = value; }
        }

        #endregion
    }
}
