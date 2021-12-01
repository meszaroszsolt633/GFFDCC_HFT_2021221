using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Client.Menus
{
    public class Statisticsmenus
    {
        public Statisticsmenus(ICarRepository carRepo, IBrandRepository brandRepo, ICarDealershipRepository cardRepo)
        {
            this.CLogic = new CarLogic(carRepo, cardRepo, brandRepo);
        }
        public CarLogic CLogic { get; set; }
        public void AVGPriceByBrands()
        {

        }
        public void CarsFromHasznaltauto()
        {

        }
        public void CarsByCountry()
        {

        }
        public void BrandPopularityByCars()
        {

        }
        public void AverageCarPriceByBrandsHigherThan()
        {

        }
    }
}
