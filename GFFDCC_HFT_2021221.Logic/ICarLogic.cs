using GFFDCC_HFT_2021221.Models;
using System.Collections.Generic;

namespace GFFDCC_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        double AVGPrice();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
        void Create(Car car);
        void Delete(int id);
        Car Read(int id);
        IEnumerable<Car> ReadAll();
        void Update(Car car);
        IEnumerable<Car> CarsFromHasznaltauto();
        IEnumerable<Car> CarsByCountry(string country);
        IEnumerable<KeyValuePair<string, double>> BrandPopularityByCars();
        IEnumerable<AveragePriceResult> AverageCarPriceByBrandsHigherThan(int minavg);


    }
}