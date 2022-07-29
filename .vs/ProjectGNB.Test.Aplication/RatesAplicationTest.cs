using Moq;
using NUnit.Framework;
using ProjectGNB.Aplication.Rate;
using ProjectGNB.Cross.EntityResult;
using ProjectGNB.Domain.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Test.Aplication
{
    class RatesAplicationTest
    {
        


        private Mock<IRatesDomain> mockRatesDomain;

        private RatesAplication ratesAplication;
        [SetUp]
        public void Setup()
        {
            this.mockRatesDomain = new Mock<IRatesDomain>();
            this.ratesAplication = new RatesAplication(this.mockRatesDomain.Object);
        }

        [Test]
        public async Task GetRatesOK()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockRatesDomain
                .Setup(p => p.GetAllRate())
                .ReturnsAsync(resultServices);

            // Execute
            await this.ratesAplication.GetAllRate().ConfigureAwait(false);
            // Assert
            this.mockRatesDomain.Verify(m => m.GetAllRate(), Times.Once);
        }

        [Test]
        public async Task GetRatesException()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockRatesDomain
                .Setup(p => p.GetAllRate())
                .ThrowsAsync(new Exception());

            // Execute
            await this.ratesAplication.GetAllRate().ConfigureAwait(false);
            // Assert
            this.mockRatesDomain.Verify(m => m.GetAllRate(), Times.Once);
        }

    }
}
