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

        public double AVGPrice()
        {
            return carRepo.ReadAll().Average(t => t.BasePrice);
        }
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
        public IEnumerable<Car> CarsByCountry(string country)
        {
            var x1 = from x in carRepo.ReadAll()
                     join cardealership in dealershipRepo.ReadAll()
                     on x.CarDealershipID equals cardealership.Id
                     where cardealership.Country == country
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
        public IEnumerable<KeyValuePair<string,double>> BrandPopularityByCars()
        {
            return from x in carRepo.ReadAll()
                   join y in brandRepo.ReadAll()
                   on x.BrandId equals y.Id
                   group x by y.Name into z
                   select new KeyValuePair<string, double>
                   (z.Key, z.Count());
                   

        }
        public IEnumerable<AveragePriceResult> AverageCarPriceByBrandsHigherThan(int minavg)
        {
            var test =  from x in carRepo.ReadAll()
                   join y in brandRepo.ReadAll()
                   on x.BrandId equals y.Id
                   group x by y.Name into z
                   where z.Average(xx => xx.BasePrice) > minavg
                   orderby z.Average(xx => xx.BasePrice) descending
                   select new AveragePriceResult()
                   {
                       Avgprice=z.Average(x=>x.BasePrice),
                       Brand=z.Key,

                   };
            if(minavg>=0 && test.ToList().Count>=1)
            {
                return test.ToList();
            }
            else
            {
                throw new ArgumentException("The average is higher than max average, or a negative number.");
            }
        }

    }
}
