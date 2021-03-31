using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMangement
{
    public class ViewReport
    {
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public string AccountType { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Decimal DepositAmount { get; set; }
    }
}
