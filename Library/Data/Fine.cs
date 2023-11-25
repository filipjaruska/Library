using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Fine
    {
        public int FineId { get; set; }
        public int LoanId { get; set; }
        public double FineAmount { get; set; }
        public bool FinePaid { get; set; }
        public string FineReason { get; set; }

        // Navigation property
        public Loan Loan { get; set; }
    }
}
