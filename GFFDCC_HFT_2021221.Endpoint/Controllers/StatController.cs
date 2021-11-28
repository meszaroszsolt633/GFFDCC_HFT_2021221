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

        [HttpGet]
        public double AVGPrice()
        {
            return cl.AVGPrice();

        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>> AVGPricebyBrands()
        {
            return cl.AVGPriceByBrands();
        }

    }
}
