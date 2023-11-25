using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class BookCopy
    {
        public int CopyId { get; set; }
        public int BookId { get; set; }
        public int BranchId { get; set; }
        public string CopyCondition { get; set; }
        public int CopyAcquisitionYear { get; set; }
        public bool CopyAvailable { get; set; }

        // Navigation properties
        public Book Book { get; set; }
        public LibraryBranch LibraryBranch { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
