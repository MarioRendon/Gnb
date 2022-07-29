using ProjectGNB.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGNB.Cross.Conversion
{
    public static class CurrencyExchange
    {
        /// <summary>
        /// method to validate if the currency arrives in EUR or search for the conversion
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="lRates"></param>
        /// <returns></returns>
        public static string ToEUR(string amount, string currency, List<Rates> lRates)
        {
            
            if (currency == Constants.Constants.ExchangeEUR)
                return amount;

            return SearchRates(amount, currency, lRates);
        }
        /// <summary>
        /// method to convert currency to EUR
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="lRates"></param>
        /// <returns></returns>
        private static string SearchRates(string amount,string currency, List<Rates> lRates)
        {
            Rates rates = lRates.FirstOrDefault(x => x.From == currency && x.To== Constants.Constants.ExchangeEUR);
            if (rates == null)
            {
                rates = lRates.FirstOrDefault(x => x.From == currency);
            }
            amount = (Convert.ToDecimal(amount) * Convert.ToDecimal(rates.Rate)).ToString();
            if (rates.To == Constants.Constants.ExchangeEUR)
            {
                return amount;
            }
            return SearchRates(amount, rates.To, lRates);
        }

    }
}
