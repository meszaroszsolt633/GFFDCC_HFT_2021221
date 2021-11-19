using GFFDCC_HFT_2021221.Models;
using GFFDCC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Logic
{
    public class CarDealershipLogic : ICarDealershipLogic
    {
        ICarDealershipRepository carDealershipRepo;
        public CarDealershipLogic(ICarDealershipRepository carDealershipRepo)
        {
            this.carDealershipRepo = carDealershipRepo;
        }
        public void Create(CarDealership cardealership)
        {
            carDealershipRepo.Create(cardealership);
        }
        public CarDealership Read(int id)
        {
            return carDealershipRepo.Read(id);
        }
        public IEnumerable<CarDealership> ReadAll()
        {
            return carDealershipRepo.ReadAll();
        }
        public void Delete(int id)
        {
            carDealershipRepo.Delete(id);
        }
        public void Update(CarDealership cardealership)
        {
            carDealershipRepo.Update(cardealership);
        }
        
    }
}
