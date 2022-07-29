using ProjectGNB.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGNB.Cross.ApiRestSharp
{
    public interface ICallApiRestSharp
    {
        List<Transactions> GetTransactionsAPiRestSharp();
        List<Transactions> GetTransactionsAPiRestSharp(string sku);

        List<Rates> GetRatesAPiRestSharp();

    }
}
