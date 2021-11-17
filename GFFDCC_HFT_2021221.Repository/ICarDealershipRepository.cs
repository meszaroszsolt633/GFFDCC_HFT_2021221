using GFFDCC_HFT_2021221.Models;
using System.Linq;

namespace GFFDCC_HFT_2021221.Repository
{
    public interface ICarDealershipRepository
    {
        void Create(CarDealership cardealership);
        void Delete(int id);
        CarDealership Read(int id);
        IQueryable<CarDealership> ReadAll();
        void Update(CarDealership cardealership);
    }
}