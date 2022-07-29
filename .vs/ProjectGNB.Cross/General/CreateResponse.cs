using ProjectGNB.Cross.EntityResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGNB.Cross.General
{
    public static class CreateResponse
    {
        public static async Task<ResultServices> Create(int code = 0, string message = "", object result = null)
        {

           ResultServices resultServices = new ResultServices(){
                code = code,
                description = message,
                additional = result
            };

            return await Task<ResultServices>.FromResult(resultServices);
        }
    }
}
