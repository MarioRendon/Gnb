using ProjectGNB.Cross;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectGNB.Data.Model;
using ProjectGNB.Cross.EntityResult;
using ProjectGNB.Cross.General;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectGNB.Cross.Constants;
using System.Linq;
using ProjectGNB.Cross.Conversion;
using ProjectGNB.Cross.ApiRestSharp;

namespace ProjectGNB.Domain.Transaction
{
    public class TransactionDomain : ITransactionDomain
    {

        public readonly ICallApiRestSharp callApiRestSharp;

        public TransactionDomain(ICallApiRestSharp callApiRestSharp)
        {
            this.callApiRestSharp = callApiRestSharp;
        }
        /// <summary>
        /// Consulta todos los Rates
        /// Check all the Rates
        /// </summary>
        /// <returns></returns>
        public async Task<ResultServices> GetAllTransaction()
        {
            try
            {
                List<Transactions> lTransactions = this.callApiRestSharp.GetTransactionsAPiRestSharp();

                return await CreateResponse.Create(StatusCodes.Status200OK, result: JsonConvert.SerializeObject(lTransactions));
            }
            catch (Exception ex)
            {
                return await CreateResponse.Create(StatusCodes.Status200OK, result: Constants.ServiceQueryError);

            }
        }

        public async Task<ResultServices> GetTransaction(string sku)
        {
            try
            {

                List<Transactions> lTransactions = this.callApiRestSharp.GetTransactionsAPiRestSharp(sku);

                List<Rates> lRates = this.callApiRestSharp.GetRatesAPiRestSharp();

                lTransactions = lTransactions.Select(x=> new Transactions { 
                    Sku= x.Sku,Currency= Constants.ExchangeEUR,Amount= CurrencyExchange.ToEUR(x.Amount,x.Currency,lRates) }).ToList();


                ResultTransactionsBySKU resultTransactionsBySKU = new ResultTransactionsBySKU()
                {
                    Transactions = lTransactions,
                    TotalAmount = lTransactions.Sum(x => Convert.ToDecimal(x.Amount)).ToString()
                };

                return await CreateResponse.Create(StatusCodes.Status200OK, result: resultTransactionsBySKU);
            }
            catch (Exception ex)
            {
                return await CreateResponse.Create(StatusCodes.Status200OK, result: Constants.ServiceQueryError);

            }
        }
    }
}
