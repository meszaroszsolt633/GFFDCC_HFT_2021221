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
    public class CardealershipController : ControllerBase
    {
        ICarDealershipLogic cdl;
        public CardealershipController(ICarDealershipLogic cdl)
        {
            this.cdl = cdl;
        }
        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<CarDealership> Get()
        {
            return cdl.ReadAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public CarDealership Get(int id)
        {
            return cdl.Read(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post([FromBody] CarDealership value)
        {
            cdl.Create(value);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] CarDealership value)
        {
            cdl.Update(value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cdl.Delete(id);
        }
    }

}
