using Microsoft.Extensions.DependencyInjection;
using ProjectGNB.Aplication.Rate;
using ProjectGNB.Aplication.Transaction;
using ProjectGNB.Cross.ApiRestSharp;
using ProjectGNB.Domain.Rate;
using ProjectGNB.Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PojectGNB.AppStart
{
    public class DependencyInjection
    {
        protected DependencyInjection() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IRatesAplication, RatesAplication>();
            services.AddScoped<IRatesDomain, RatesDomain>();

            services.AddScoped<ITransactionAplication, TransactionAplication>();
            services.AddScoped<ITransactionDomain, TransactionDomain>();


            services.AddScoped<ICallApiRestSharp, CallApiRestSharp>();
        }
    }
}
