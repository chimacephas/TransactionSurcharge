using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSurcharge.Implementation;
using Xunit;

namespace TransactionSurchargeTest
{
    public class ChargeServiceTest
    {

        public ChargeServiceTest()
        {
        }

        [Fact]
        public async Task CalculateCharge_WhenCalled_ValidPath_ReturnsFeeForTransactionAmount()
        {

            var sut = new ChargeService();

            var execPath = AppDomain.CurrentDomain.BaseDirectory;

            var contentRootPath = execPath.Substring(0, execPath.Length - 18);

            var path = Path.Combine(contentRootPath, "Files/fees.config.json");


            var result = await sut.CalculateCharge(path, 50030);



            Assert.Equal(50, result.Charge);
            Assert.Equal(50030, result.Amount);
            Assert.Equal(49980, result.TransferAmount);
            Assert.Equal(50030, result.DebitAmount);
        }

        [Fact]
        public async Task CalculateCharge_WhenCalled_InvalidPath_ThrowsFileNotFoundException()
        {

            var sut = new ChargeService();

            var execPath = AppDomain.CurrentDomain.BaseDirectory;

            var contentRootPath = execPath.Substring(0, execPath.Length - 18);

            var path = Path.Combine(contentRootPath, "Files/fee.config.json");


           await Assert.ThrowsAnyAsync<FileNotFoundException>(async ()=> { await sut.CalculateCharge(path, 50030);});
        }
    }
}
