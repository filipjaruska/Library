using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public int PublisherId { get; set; }
        public string BookIsbn { get; set; }
        public string BookTitle { get; set; }
        public int BookPublicationYear { get; set; }

        // Navigation properties
        public Publisher Publisher { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookCopy> BookCopies { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
