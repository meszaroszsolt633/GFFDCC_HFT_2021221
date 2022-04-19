using GFFDCC_HFT_2021221.Endpoint.Services;
using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public CarController(ICarLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("CarCreated", value);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Put([FromBody] Car value)
        {
            cl.Update(value);
            this.hub.Clients.All.SendAsync("CarUpdated", value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carToDelete = this.cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("CarDeleted", carToDelete);
        }
    }
}
