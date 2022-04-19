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
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;
        IHubContext<SignalRHub> hub;
        // GET: api/<BrandController>
        
        public BrandController(IBrandLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return bl.ReadAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return bl.Read(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            bl.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            bl.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brandToDelete = this.bl.Read(id);
            bl.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", brandToDelete);
        }
    }
}
