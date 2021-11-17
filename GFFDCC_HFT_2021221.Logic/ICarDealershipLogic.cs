using GFFDCC_HFT_2021221.Models;
using System.Collections.Generic;

namespace GFFDCC_HFT_2021221.Logic
{
    public interface ICarDealershipLogic
    {
        void Create(CarDealership cardealership);
        void Delete(int id);
        CarDealership Read(int id);
        IEnumerable<CarDealership> ReadAll();
        void Update(CarDealership cardealership);
    }
}