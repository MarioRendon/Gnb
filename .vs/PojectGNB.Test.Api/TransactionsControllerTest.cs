using Moq;
using NUnit.Framework;
using PojectGNB.Controllers;
using ProjectGNB.Aplication.Transaction;
using ProjectGNB.Cross.EntityResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PojectGNB.Test.Api
{
    class TransactionsControllerTest
    {
        private Mock<ITransactionAplication> mockTransactionAplication;

        private TransactionsController transactionController;
        
        [SetUp]
        public void Setup()
        {
            this.mockTransactionAplication = new Mock<ITransactionAplication>();
            this.transactionController = new TransactionsController(this.mockTransactionAplication.Object);
        }

        [Test]
        public async Task GetAllTransactionOK()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionAplication
                .Setup(p => p.GetAllTransaction())
                .ReturnsAsync(resultServices);

            // Execute
            await this.transactionController.GetAllTransaction().ConfigureAwait(false);
            // Assert
            this.mockTransactionAplication.Verify(m => m.GetAllTransaction(), Times.Once);
        }

        [Test]
        public async Task GetAllTransactionException()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionAplication
                .Setup(p => p.GetAllTransaction())
                .ThrowsAsync(new Exception());

            // Execute
            await this.transactionController.GetAllTransaction().ConfigureAwait(false);
            // Assert
            this.mockTransactionAplication.Verify(m => m.GetAllTransaction(), Times.Once);
        }

        [Test]
        public async Task GetTransactionOK()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionAplication
                .Setup(p => p.GetTransaction(It.IsAny<string>()))
                .ReturnsAsync(resultServices);

            // Execute
            await this.transactionController.GetTransaction("M4101").ConfigureAwait(false);
            // Assert
            this.mockTransactionAplication.Verify(m => m.GetTransaction("M4101"), Times.Once);
        }

        [Test]
        public async Task GetTransactionException()
        {

            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionAplication
                .Setup(p => p.GetTransaction(It.IsAny<string>()))
                .ThrowsAsync(new Exception());
            // Execute
            await this.transactionController.GetTransaction("M4101").ConfigureAwait(false);
            // Assert
            this.mockTransactionAplication.Verify(m => m.GetTransaction("M4101"), Times.Once);

        }
    }


}
