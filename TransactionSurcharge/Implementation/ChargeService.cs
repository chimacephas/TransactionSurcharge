using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TransactionSurcharge.Interfaces;
using TransactionSurcharge.Models;

namespace TransactionSurcharge.Implementation
{
    public class ChargeService : IChargeService
    {
        public async Task<TransactionResultDto> CalculateCharge(string chargeConfigFilePath, int amount)
        {

            var cofigFIle = await System.IO.File.ReadAllTextAsync(chargeConfigFilePath);


            var amountConfig = JsonSerializer.Deserialize<ChargeConfiguration>(cofigFIle);


            TransactionResultDto result = null;

            foreach (var fee in amountConfig.fees)
            {
                if (amount >= fee.minAmount && amount <= fee.maxAmount)
                {
                    result = new TransactionResultDto
                    {
                         Amount = amount,
                         Charge = fee.feeAmount,
                         TransferAmount = amount - fee.feeAmount,
                          DebitAmount = amount
                    };

                    break;
                }

            }

            return result;
        }
    }
}
