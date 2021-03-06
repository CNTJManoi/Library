namespace OOPRGR
{
    class Journal
    {
        #region Поля
        private string _name;
        private string _author;
        private ushort _yearPublication;
        private string _location;
        private uint _count;
        #endregion

        #region Конструктор
        /// <summary>
        /// Создает экземпляр книги
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="author">Автор</param>
        /// <param name="yearPublication">Год публикации</param>
        /// <param name="location">Местоположение в библиотеке</param>
        /// <param name="count">Количество экземпляров в библиотеке</param>
        public Journal(string name, string author, ushort yearPublication, string location, uint count)
        {
            _name = name;
            _author = author;
            _yearPublication = yearPublication;
            _location = location;
            _count = count;
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Возвращает наименование журнала
        /// </summary>
        public string GetName { get { return _name; } }
        /// <summary>
        /// Возвращает автора книги
        /// </summary>
        public string GetAuthor { get { return _author; } }
        /// <summary>
        /// Возвращает год издания книги
        /// </summary>
        public ushort GetYearPublication { get { return _yearPublication; } }
        /// <summary>
        /// Возвращает или задает местоположение журнала в библиотеке
        /// </summary>
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        /// <summary>
        /// Возвращает или задает количество экземпляров журнала в библиотеке
        /// </summary>
        public uint Count
        {
            get { return _count; }
            set { _count = value; }
        }

        #endregion
    }
}
