using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdPilhaLivros
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Isbn { get; set; }
        public Book Previous { get; set; }


        public override string ToString()
        {
            return "\nTitulo:" + Title + "\nAutor:" + Author + "\nISBN:" + Isbn;
        }
    }
}
