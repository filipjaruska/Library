using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }

        // Navigation properties
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
