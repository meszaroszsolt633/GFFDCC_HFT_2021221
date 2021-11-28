using GFFDCC_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICarLogic cl;
        public StatController(ICarLogic cl)
        {
            this.cl = cl;
        }
        // GET: /car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cl.ReadAll();
        }
    }
}
