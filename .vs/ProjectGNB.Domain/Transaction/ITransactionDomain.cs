using ProjectGNB.Cross.EntityResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Domain.Transaction
{
    public interface ITransactionDomain
    {
        Task<ResultServices> GetAllTransaction();

        Task<ResultServices> GetTransaction(string sku);
    }
}
