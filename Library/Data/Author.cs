using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }

        // Navigation property for the relationship between Author and BookAuthor
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
