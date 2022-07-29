using ProjectGNB.Cross.EntityResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Aplication.Rate
{
    public interface IRatesAplication
    {
        Task<ResultServices> GetAllRate();
    }
}
