using ProjectGNB.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGNB.Cross.EntityResult
{
    public class ResultTransactionsBySKU
    {
        /// <summary>
        /// show all transactions
        /// </summary>
        public List<Transactions> Transactions { get; set; }

        /// <summary>
        /// show the sum of the value of the transactions
        /// </summary>
        public string TotalAmount { get; set; }
    }
}
