using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGNB.Aplication.Rate;
using ProjectGNB.Cross.EntityResult;
using ProjectGNB.Cross.General;
using ProjectGNB.Data.Model;

namespace PojectGNB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        IRatesAplication ratesAplication;
        public RatesController(IRatesAplication ratesAplication)
        {
            this.ratesAplication = ratesAplication;
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Rates))]
        [ProducesResponseType(400)]
        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                ResultServices result = await ratesAplication.GetAllRate();
                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, CreateResponse.Create(0, ex.Message));
            }
        }
    }
}
