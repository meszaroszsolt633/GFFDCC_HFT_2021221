using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Models;
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
        IBrandLogic bl;
        ICarDealershipLogic cdl;
        public StatController(ICarLogic cl, IBrandLogic bl, ICarDealershipLogic cdl)
        {
            this.cl = cl;
            this.bl = bl;
            this.cdl = cdl;
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
        [HttpGet]
        public IEnumerable<Car> CarsFromHasznaltauto()
        {
            return cl.CarsFromHasznaltauto();

        }
        [HttpGet]
        public IEnumerable<Car> CarsByCountry(string country)
        {
            return cl.CarsByCountry(country);

        }
        [HttpGet]
        public IEnumerable<AveragePriceResult> AverageCarPriceByBrandsHigherThan(int minavg)
        {
            return cl.AverageCarPriceByBrandsHigherThan(minavg);

        }

    }
}
