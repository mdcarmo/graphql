using ex_graphql.Contracts;
using ex_graphql.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace ex_graphql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _repository;
        public OrderController(ILogger<OrderController> logger, IOrderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/TodoItems
        [HttpGet]
        [SwaggerOperation(Summary = "Get all orders", Description = "Get all orders")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                throw;
            }
        }        
    }
}
