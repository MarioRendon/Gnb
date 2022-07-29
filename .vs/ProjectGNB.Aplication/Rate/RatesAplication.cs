using Microsoft.AspNetCore.Http;
using ProjectGNB.Cross.Constants;
using ProjectGNB.Cross.EntityResult;
using ProjectGNB.Cross.General;
using ProjectGNB.Domain.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Aplication.Rate
{
    public class RatesAplication : IRatesAplication
    {
        private readonly IRatesDomain ratesDomain;

        public RatesAplication(IRatesDomain ratesDomain)
        {
            this.ratesDomain = ratesDomain;
        }
        public Task<ResultServices> GetAllRate()
        {
            try
            {

                return this.ratesDomain.GetAllRate();
            }

            catch (Exception)
            {
                return CreateResponse.Create(StatusCodes.Status400BadRequest, result: Constants.ServiceQueryError);

            }
        }
    }
}
