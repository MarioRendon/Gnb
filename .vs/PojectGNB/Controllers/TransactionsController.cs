using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGNB.Aplication.Transaction;
using ProjectGNB.Cross.EntityResult;
using ProjectGNB.Cross.General;
using ProjectGNB.Data.Model;

namespace PojectGNB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        ITransactionAplication transactionAplication;
        public TransactionsController(ITransactionAplication transactionAplication)
        {
            this.transactionAplication = transactionAplication;
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Transactions))]
        [ProducesResponseType(400)]
        [HttpGet()]
        public async Task<ActionResult> GetAllTransaction()
        {
            try
            {
                ResultServices result = await this.transactionAplication.GetAllTransaction();
                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, CreateResponse.Create(0, ex.Message));
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Transactions))]
        [ProducesResponseType(400)]
        [HttpGet("{sku}")]
        public async Task<ActionResult> GetTransaction(string sku)
        {
            try
            {
                ResultServices result = await this.transactionAplication.GetTransaction(sku);
                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, CreateResponse.Create(0, ex.Message));
            }
        }
    }
}
