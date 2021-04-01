using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionSurcharge.Models
{
    public class TransactionResultDto
    {
        public int Amount { get; set; }
        public int TransferAmount { get; set; }
        public int Charge { get; set; }
        public int DebitAmount { get; set; }
    }
}
