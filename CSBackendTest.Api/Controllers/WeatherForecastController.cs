using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSBackendTest.Data.Context;
using CSBackendTest.Data.Models;
using CSBackendTest.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSBackendTest.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, BackendTestContext context, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public void Create([FromQuery] string name, [FromQuery] string surname)
        {
            var customer = new Customer
            {
                Name = name, 
                Surname = surname,
                Id = Guid.NewGuid(),
            };
            _repository.Add(customer);
        }
        
        [HttpDelete]
        public async Task Delete([FromQuery] Guid id)
        {
            await _repository.Delete(id);
        }
        
        [HttpPatch]
        public async Task Update([FromBody] Customer entity)
        {
            await _repository.Update(entity);
        }

        [HttpGet]
        public List<Customer> Get()
        {
            return _repository.GetAll().ToList();
        }
        
        [HttpGet("{id}")]
        public List<Customer> Get([FromQuery] Guid id)
        {
            return _repository.GetAll().ToList();
        }
    }
}