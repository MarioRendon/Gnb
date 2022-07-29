using ProjectGNB.Cross.EntityResult;
using System.Threading.Tasks;
using System;
using ProjectGNB.Cross.General;
using Newtonsoft.Json;
using System.Collections.Generic;
using ProjectGNB.Cross;
using ProjectGNB.Data;
using ProjectGNB.Data.Model;
using Microsoft.AspNetCore.Http;
using ProjectGNB.Cross.Constants;
using ProjectGNB.Cross.ApiRestSharp;

namespace ProjectGNB.Domain.Rate
{
    public class RatesDomain : IRatesDomain
    {

        public readonly ICallApiRestSharp callApiRestSharp;

        public RatesDomain(ICallApiRestSharp callApiRestSharp)
        {
            this.callApiRestSharp = callApiRestSharp;
        }


        /// <summary>
        /// Consulta todos los Rates
        /// Check all the Rates
        /// </summary>
        /// <returns></returns>
        public async Task<ResultServices> GetAllRate()
        {
            try
            {
                List<Rates> lRates = this.callApiRestSharp.GetRatesAPiRestSharp();//  CallAPiRestSharp.GetRatesAPiRestSharp();

                return await CreateResponse.Create(StatusCodes.Status200OK, result: JsonConvert.SerializeObject(lRates));
            }
            catch (Exception)
            {
                return await CreateResponse.Create(StatusCodes.Status400BadRequest, result: Constants.ServiceQueryError);
                
            }
        }
    }
}
