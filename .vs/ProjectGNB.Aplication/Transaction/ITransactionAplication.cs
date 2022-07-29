using ProjectGNB.Cross.EntityResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Aplication.Transaction
{
    public interface ITransactionAplication
    {
        Task<ResultServices> GetAllTransaction();

        Task<ResultServices> GetTransaction(string sku);
    }
}
