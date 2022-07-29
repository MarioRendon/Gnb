using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using ProjectGNB.Data;
using ProjectGNB.Data.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ProjectGNB.Cross.ApiRestSharp
{
    public class CallApiRestSharp : ICallApiRestSharp
    {

        private readonly IDistributedCache memoryCache;

        public CallApiRestSharp(IDistributedCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public List<Transactions> GetTransactionsAPiRestSharp()
        {
            List<Transactions> transactions = ApiRestSharp<Transactions>.MethodGet(Constants.Constants.UrlServiceTransaction, "Transactions");
            SaveRedisCacheData("Transactions", JsonConvert.SerializeObject(transactions));
            return transactions ;
        }

        /// <summary>
        /// Method to query transactions and filter by SKU code
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public List<Transactions> GetTransactionsAPiRestSharp(string sku)
        {
            List<Transactions> transactions = ApiRestSharp<Transactions>.MethodGet(Constants.Constants.UrlServiceTransaction, "Transactions");
            SaveRedisCacheData("Transactions", JsonConvert.SerializeObject(transactions));
            return transactions.Where(x => x.Sku == sku).ToList();
        }
        /// <summary>
        /// Methods to consult currency rates
        /// </summary>
        /// <returns></returns>
        public List<Rates> GetRatesAPiRestSharp()
        {
            List<Rates> lRates = ApiRestSharp<Rates>.MethodGet(Constants.Constants.UrlServiceRates,  "Rates");
            
            if(lRates!=null)
                SaveRedisCacheData("Rates", JsonConvert.SerializeObject(lRates));

            var data= System.Text.Json.JsonSerializer.Deserialize<List<Rates>>(memoryCache.Get("Rates"));
            return lRates?? data;
        }

        private void SaveRedisCacheData(string key, string valor)
        {
            memoryCache.SetAsync(key, System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(valor));
        }



    }

    public static class ApiRestSharp<T>
    {

        public static List<T> MethodGet(string url, string key)
        {
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                List<T> lItems = JsonConvert.DeserializeObject<List<T>>(response.Content);

                return lItems;
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}
