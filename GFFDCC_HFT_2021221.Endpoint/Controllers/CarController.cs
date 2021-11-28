using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GFFDCC_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic cl;
        public CarController(ICarLogic cl)
        {
            this.cl = cl;
        }
        // GET: /car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cl.ReadAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return cl.Read(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            cl.Create(value);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Car value)
        {
            cl.Update(value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
