using ex_graphql.Contracts;
using ex_graphql.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(string id)
        {
            try
            {
                var result = await _repository.GetAllByCustomer(new Guid(id));
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                throw;
            }
        }
    }
}
