using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGNB.Data.Model
{
    [Keyless]
    public class Transactions
    {
        /// <summary>
        /// transaction identification code
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// the value of the transaction
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// The currency used for the transaction
        /// </summary>
        public string Currency { get; set; }
    }
}
