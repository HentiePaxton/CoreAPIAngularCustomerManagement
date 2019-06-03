using System;
using System.Collections.Generic;

namespace CompanyAPP.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Note = new HashSet<Note>();
        }

        public int PkCustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string CellNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public Guid? CustomerId { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string PassportNo { get; set; }
        public int? FkStatusId { get; set; }

        public Status FkStatus { get; set; }
        public ICollection<Note> Note { get; set; }
    }
}
