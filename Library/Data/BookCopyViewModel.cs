using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    internal class BookCopyViewModel
    {
        public int CopyId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Condition { get; set; }
        public int Acquisition { get; set; }
        public bool Available { get; set; }
    }
}
