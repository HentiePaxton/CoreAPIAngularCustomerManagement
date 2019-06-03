using System;
using System.Collections.Generic;

namespace CompanyAPP.Models
{
    public partial class Status
    {
        public Status()
        {
            Customer = new HashSet<Customer>();
        }

        public int PkStatusId { get; set; }
        public string Status1 { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
