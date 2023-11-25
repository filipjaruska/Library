using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Patron
    {
        public int PatronId { get; set; }
        public string PatronFirstName { get; set; }
        public string PatronLastName { get; set; }
        public string PatronAddress { get; set; }

        // Navigation property
        public ICollection<Loan> Loans { get; set; }
    }
}
