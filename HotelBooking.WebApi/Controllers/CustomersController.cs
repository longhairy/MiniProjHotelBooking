using System.Collections.Generic;
using HotelBooking.Core;
using Microsoft.AspNetCore.Mvc;


namespace HotelBooking.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer> repository;

        public CustomersController(IRepository<Customer> repos)
        {
            repository = repos;
        }

        // GET: customers
        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<Customer> Get()
        {
            return repository.GetAll();
        }

        //// GET: customers
        //[HttpGet]
        //public IEnumerable<Customer> Get()
        //{
        //    return repository.GetAll();
        //}
        // POST Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            repository.Add(customer);
            return CreatedAtRoute("GetCustomers", null);
        }
    }
}
