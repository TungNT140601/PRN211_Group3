using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Member
    {
        public Member()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public int MemberId { get; set; }
        public string Email { get; set; }
        public string Companyname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
