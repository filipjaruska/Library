using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string PublisherLocation { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
