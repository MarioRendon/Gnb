using Moq;
using NUnit.Framework;
using ProjectGNB.Aplication.Transaction;
using ProjectGNB.Cross.EntityResult;
using ProjectGNB.Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Test.Aplication
{
    class TransactionAplicationTest
    {
        private Mock<ITransactionDomain> mockTransactionDomain;

        private TransactionAplication transactionAplication;

        [SetUp]
        public void Setup()
        {
            this.mockTransactionDomain = new Mock<ITransactionDomain>();
            this.transactionAplication = new TransactionAplication(this.mockTransactionDomain.Object);
        }

        [Test]
        public async Task GetAllTransactionOK()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionDomain
                .Setup(p => p.GetAllTransaction())
                .ReturnsAsync(resultServices);

            // Execute
            await this.transactionAplication.GetAllTransaction().ConfigureAwait(false);
            // Assert
            this.mockTransactionDomain.Verify(m => m.GetAllTransaction(), Times.Once);
        }

        [Test]
        public async Task GetAllTransactionException()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionDomain
                .Setup(p => p.GetAllTransaction())
                .ThrowsAsync(new Exception());

            // Execute
            await this.transactionAplication.GetAllTransaction().ConfigureAwait(false);
            // Assert
            this.mockTransactionDomain.Verify(m => m.GetAllTransaction(), Times.Once);
        }

        [Test]
        public async Task GetTransactionOK()
        {
            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionDomain
                .Setup(p => p.GetTransaction(It.IsAny<string>()))
                .ReturnsAsync(resultServices);

            // Execute
            await this.transactionAplication.GetTransaction("M4101").ConfigureAwait(false);
            // Assert
            this.mockTransactionDomain.Verify(m => m.GetTransaction("M4101"), Times.Once);
        }

        [Test]
        public async Task GetTransactionException()
        {

            ResultServices resultServices = new ResultServices();
            // Prepare
            this.mockTransactionDomain
                .Setup(p => p.GetTransaction(It.IsAny<string>()))
                .ThrowsAsync(new Exception());
            // Execute
            await this.transactionAplication.GetTransaction("M4101").ConfigureAwait(false);
            // Assert
            this.mockTransactionDomain.Verify(m => m.GetTransaction("M4101"), Times.Once);

        }
    }
}
