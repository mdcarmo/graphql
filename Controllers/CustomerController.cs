using ex_graphql.Contracts;
using ex_graphql.Entities;
using ex_graphql.Entities.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ex_graphql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _repository;
        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all customers (does not return orders)", Description = "Get all customers (does not return orders)")]
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
        [SwaggerOperation(Summary = "Get customer by id - is it possible to return the orders or not", Description = "Get customer by id - is it possible to return the orders or not")]
        public async Task<ActionResult> GetById(string id, bool returnOrders)
        {
            try
            {
                var result = await _repository.GetById(new Guid(id), returnOrders);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                throw;
            }
        }
    }
}
