using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Staff
    {
        public int StaffId { get; set; }
        public int BranchId { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffLastName { get; set; }
        public string StaffPosition { get; set; }
        public double StaffSalary { get; set; }

        // Navigation property
        public LibraryBranch LibraryBranch { get; set; }
    }
}
