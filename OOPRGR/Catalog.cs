using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Catalog
    {
        private List<Book> _avaliableBooks;
        public Catalog()
        {
            _avaliableBooks = new List<Book>();
        }
        public List<Book> GetCatalog { get { return _avaliableBooks; } }
        public void AddBooks(Book b)
        {
            _avaliableBooks.Add(b);
        }
    }
}
