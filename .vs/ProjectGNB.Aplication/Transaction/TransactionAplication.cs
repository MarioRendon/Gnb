using Microsoft.AspNetCore.Http;
using ProjectGNB.Cross.Constants;
using ProjectGNB.Cross.EntityResult;
using ProjectGNB.Cross.General;
using ProjectGNB.Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Aplication.Transaction
{
    public class TransactionAplication: ITransactionAplication
    {
        private readonly ITransactionDomain transactionDomain;

        public TransactionAplication(ITransactionDomain transactionDomain)
        {
            this.transactionDomain = transactionDomain;
        }
        public Task<ResultServices> GetAllTransaction()
        {
            try
            {
                return this.transactionDomain.GetAllTransaction();
            }
            catch (Exception)
            {
                return CreateResponse.Create(StatusCodes.Status400BadRequest, result: Constants.ServiceQueryError);

            }
            
        }

       public Task<ResultServices> GetTransaction(string sku) {

            try
            {
                return this.transactionDomain.GetTransaction(sku);
            }
            
            catch (Exception)
            {
                return CreateResponse.Create(StatusCodes.Status400BadRequest, result: Constants.ServiceQueryError);

            }
            
        }
    }
}
