using GFFDCC_HFT_2021221.Models;
using GFFDCC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepository carRepo;
        ICarDealershipRepository dealershipRepo;
        IBrandRepository brandRepo;
        public CarLogic(ICarRepository carRepo, ICarDealershipRepository dealershipRepo, IBrandRepository brandRepo)
        {
            this.carRepo = carRepo;
            this.dealershipRepo = dealershipRepo;
            this.brandRepo=brandRepo;
        }
        public void Create(Car car)
        {
            if (car.BasePrice < 0)
            {
                throw new ArgumentException("Negative price is not valid.");
            }
            carRepo.Create(car);
        }
        public Car Read(int id)
        {
            return carRepo.Read(id);
        }
        public IEnumerable<Car> ReadAll()
        {
            return carRepo.ReadAll();
        }
        public void Delete(int id)
        {
            carRepo.Delete(id);
        }
        public void Update(Car car)
        {
            carRepo.Update(car);
        }

        //non-crud
        //Average price

        public double AVGPrice()
        {
            return carRepo.ReadAll().Average(t => t.BasePrice);
        }
        //Average price by brands
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return from x in carRepo.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice));
        }
        public IEnumerable<Car> CarsFromHasznaltauto()
        {
            var x1 = from x in carRepo.ReadAll()
                     join cardealership in dealershipRepo.ReadAll()
                     on x.CarDealershipID equals cardealership.Id
                     where cardealership.Name == "Használtautók"
                     select new Car
                     {
                         Id = x.Id,
                         Model = x.Model,
                         BasePrice = x.BasePrice,
                         BrandId = x.BrandId,
                         CarDealershipID = x.CarDealershipID
                     };
            return x1;
        }
        public IEnumerable<Car> CarsByBrand(int price)
        {
            var q = from x in carRepo.ReadAll()
                    join 
        }

    }
}
