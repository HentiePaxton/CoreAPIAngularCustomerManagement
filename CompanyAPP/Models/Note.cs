using System;
using System.Collections.Generic;

namespace CompanyAPP.Models
{
    public partial class Note
    {
        public int PkNoteId { get; set; }
        public string Note1 { get; set; }
        public int? FkCustomerId { get; set; }

        public Customer FkCustomer { get; set; }
    }
}
