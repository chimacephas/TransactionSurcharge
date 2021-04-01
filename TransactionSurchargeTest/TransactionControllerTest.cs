using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSurcharge.Controllers;
using TransactionSurcharge.Interfaces;
using TransactionSurcharge.Models;
using Xunit;

namespace TransactionSurchargeTest
{
    public class TransactionControllerTest
    {
        private readonly Mock<IChargeService> chargeService;
        private readonly Mock<IWebHostEnvironment> hostenvireonment;
        public TransactionControllerTest()
        {
            chargeService = new Mock<IChargeService>();
            hostenvireonment = new Mock<IWebHostEnvironment>();

        }

        [Fact]
        public async Task ProcessPayment_WhenCalled_ValidAmount_ReturnsTransactionFee()
        {

            chargeService.Setup(x => x.CalculateCharge(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new TransactionResultDto());
            hostenvireonment.Setup(x => x.WebRootPath).Returns("C:\\Users");

            var sut = new TransactionController(hostenvireonment.Object, chargeService.Object);



            var result = await sut.ProcessPayment(new TransactionDto { Amount = 5000 });


            chargeService.Verify(x => x.CalculateCharge(It.IsAny<string>(), It.IsAny<int>()), Times.Once);

            Assert.IsType<OkObjectResult>(result);

        }

      
    }
}
