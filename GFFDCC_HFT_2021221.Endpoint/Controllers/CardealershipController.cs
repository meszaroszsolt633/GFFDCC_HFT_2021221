using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GFFDCC_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardealershipController : ControllerBase
    {
        // GET: api/<CardealershipController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CardealershipController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CardealershipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CardealershipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CardealershipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
