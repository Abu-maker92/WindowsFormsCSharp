using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMangement
{
    public class Customer
    {
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public string FathersName { get; set; }
        public int AccountTypeId { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Ocupation { get; set; }
        public string PhoneNo { get; set; }
        public Decimal DepositAmount { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
    }
}
