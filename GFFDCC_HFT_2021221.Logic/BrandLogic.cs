using GFFDCC_HFT_2021221.Models;
using GFFDCC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        ICarRepository carRepo;
        ICarDealershipRepository dealershipRepo;
        IBrandRepository brandRepo;
        public BrandLogic(ICarRepository carRepo, ICarDealershipRepository dealershipRepo, IBrandRepository brandRepo)
        {
            this.carRepo = carRepo;
            this.dealershipRepo = dealershipRepo;
            this.brandRepo = brandRepo;
        }
        public void Create(Brand brand)
        {
            brandRepo.Create(brand);
        }
        public Brand Read(int id)
        {
            return brandRepo.Read(id);
        }
        public IEnumerable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }
        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }
        public void Update(Brand brand)
        {
            brandRepo.Update(brand);
        }
    }
}
