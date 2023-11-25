using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryBranch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }

        // Navigation properties
        public ICollection<BookCopy> BookCopies { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
