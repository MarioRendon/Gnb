using Moq;
using NUnit.Framework;
using PojectGNB.Controllers;
using ProjectGNB.Aplication.Rate;
using ProjectGNB.Cross.EntityResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PojectGNB.Test.Api
{
    public class RatesControllerTest
    {

        private Mock<IRatesAplication> mockRatesAplication;

        private RatesController ratesController;
        [SetUp]
        public void Setup()
        {
            this.mockRatesAplication = new Mock<IRatesAplication>();
            this.ratesController = new RatesController(this.mockRatesAplication.Object);
        }

        [Test]
        public async Task GetRatesOK()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockRatesAplication
                .Setup(p => p.GetAllRate())
                .ReturnsAsync(resultServices);

            // Execute
            await this.ratesController.GetAll().ConfigureAwait(false);
            // Assert
            this.mockRatesAplication.Verify(m => m.GetAllRate(), Times.Once);
        }

        [Test]
        public async Task GetRatesException()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockRatesAplication
                .Setup(p => p.GetAllRate())
                .ThrowsAsync(new Exception());

            // Execute
            await this.ratesController.GetAll().ConfigureAwait(false);
            // Assert
            this.mockRatesAplication.Verify(m => m.GetAllRate(), Times.Once);
        }
    }
}
