using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFFDCC_HFT_2021221.Data;
using GFFDCC_HFT_2021221.Models;

namespace GFFDCC_HFT_2021221.Repository
{
    public class CarDealershipRepository : ICarDealershipRepository
    {
        CarDbContext db;
        public CarDealershipRepository(CarDbContext db)
        {
            this.db = db;
        }
        public void Create(CarDealership cardealership)
        {
            db.CarDealerships.Add(cardealership);
            db.SaveChanges();
        }
        public CarDealership Read(int id)
        {
            return db.CarDealerships.FirstOrDefault(t => t.Id == id);
        }
        public IQueryable<CarDealership> ReadAll()
        {
            return db.CarDealerships;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(CarDealership cardealership)
        {
            var oldCarDealership = Read(cardealership.Id);
            oldCarDealership.Name = cardealership.Name;
            oldCarDealership.Address = cardealership.Address;
            oldCarDealership.Taxnumber = cardealership.Taxnumber;
            db.SaveChanges();
        }

    }
}
