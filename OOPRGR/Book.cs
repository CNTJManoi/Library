using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OOPRGR
{
    class Book
    {
        private string _author;
        private string _publication;
        private ushort _yearPublication;
        private string _genre;
        private uint _numberPages;
        private string _ISBN;
        private string _location;
        private uint _count;

        public Book(string author, string publication, ushort yearPublication, string genre, uint numberPages, string ISBN, string location, uint count)
        {
            _author = author;
            _publication = publication;
            _yearPublication = yearPublication;
            _genre = genre;
            _numberPages = numberPages;
            _ISBN = ISBN;
            _location = location;
            _count = count;
        }

    }
}
