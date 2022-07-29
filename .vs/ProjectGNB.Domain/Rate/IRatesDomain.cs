using ProjectGNB.Cross.EntityResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Domain.Rate
{
    public interface IRatesDomain
    {
        Task<ResultServices> GetAllRate();
    }
}
