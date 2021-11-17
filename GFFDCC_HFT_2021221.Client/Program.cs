using GFFDCC_HFT_2021221.Data;
using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Repository;
using System;

namespace GFFDCC_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDbContext db = new CarDbContext();

            CarLogic c1 = new CarLogic(new CarRepository(db));

            BrandLogic b1 = new BrandLogic(new BrandRepository(db));

            var q = c1.AVGPrice();
            var q2 = c1.AVGPriceByBrands();

            ;
        }
    }
}
