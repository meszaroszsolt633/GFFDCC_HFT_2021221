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
        ICarRepository carRepo;
        ICarDealershipRepository dealershipRepo;
        IBrandRepository brandRepo;
        public CarDealershipLogic(ICarRepository carRepo, ICarDealershipRepository dealershipRepo, IBrandRepository brandRepo)
        {
            this.carRepo = carRepo;
            this.dealershipRepo = dealershipRepo;
            this.brandRepo = brandRepo;
        }
        public void Create(CarDealership cardealership)
        {
            dealershipRepo.Create(cardealership);
        }
        public CarDealership Read(int id)
        {
            return dealershipRepo.Read(id);
        }
        public IEnumerable<CarDealership> ReadAll()
        {
            return dealershipRepo.ReadAll();
        }
        public void Delete(int id)
        {
            dealershipRepo.Delete(id);
        }
        public void Update(CarDealership cardealership)
        {
            dealershipRepo.Update(cardealership);
        }
        public IList<CarDealership> GetAllCardealerships()
        {
            return this.dealershipRepo.ReadAll().ToList();
        }
        
    }
}
