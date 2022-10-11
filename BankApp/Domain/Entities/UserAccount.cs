using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Entities
{
    public class UserAccount
    {
        public int Password { get; set; }
        public long AccountNumber { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public decimal  AccountBalance { get; set; }
        public int TotalLogin { get; set; }
        public bool IsNotAUser{ get; set; }



    }
}
