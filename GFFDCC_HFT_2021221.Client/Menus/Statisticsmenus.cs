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
            foreach (var item in this.CLogic.AVGPriceByBrands())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
        public void CarsFromHasznaltauto()
        {
            foreach (var item in this.CLogic.CarsFromHasznaltauto())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
        public void CarsByCountry()
        {
            Console.WriteLine("Enter country:");
            string input = Console.ReadLine();
            foreach (var item in this.CLogic.CarsByCountry(input))
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();

        }
        public void BrandPopularityByCars()
        {
            foreach (var item in this.CLogic.BrandPopularityByCars())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
        public void AverageCarPriceByBrandsHigherThan()
        {
            Console.WriteLine("Give the avg price:");
            bool input = int.TryParse(Console.ReadLine(), out int avg);
            if (input)
            {
                try
                {
                    foreach (var item in this.CLogic.AverageCarPriceByBrandsHigherThan(avg))
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Give an integer number please!");
            }

            Console.ReadLine();

        }
    }
}
