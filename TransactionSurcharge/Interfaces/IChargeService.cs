using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionSurcharge.Models;

namespace TransactionSurcharge.Interfaces
{
    public interface IChargeService
    {
        Task<TransactionResultDto> CalculateCharge(string chargeConfigFilePath, int amount);
    }
}
