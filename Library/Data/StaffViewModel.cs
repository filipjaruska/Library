using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    internal class StaffViewModel
    {
        public int StaffId { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string StaffName { get; set; }
        public string Possition { get; set; }
        public double Salary { get; set; }
    }
}
