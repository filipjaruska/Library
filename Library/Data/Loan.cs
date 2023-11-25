using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Loan
    {
        public int BookId { get; set; }
        public int LoanId { get; set; }
        public int? CopyId { get; set; }
        public int PatronId { get; set; }
        public DateTime LoanStartDate { get; set; }
        public DateTime LoanEndDate { get; set; }

        // Navigation properties
        public BookCopy BookCopy { get; set; }
        public Patron Patron { get; set; }
        public ICollection<Fine> Fines { get; set; }
    }
}
