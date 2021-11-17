using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFFDCC_HFT_2021221.Data;
using GFFDCC_HFT_2021221.Models;

namespace GFFDCC_HFT_2021221.Repository
{
    public class CarRepository : ICarRepository
    {
        CarDbContext db;
        public CarRepository(CarDbContext db)
        {
            this.db = db;
        }
        public void Create(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }
        public Car Read(int id)
        {
            return db.Cars.FirstOrDefault(t => t.Id == id);
        }
        public IQueryable<Car> ReadAll()
        {
            return db.Cars;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Car car)
        {
            var oldcar = Read(car.Id);
            oldcar.BasePrice = car.BasePrice;
            oldcar.Model = car.Model;
            oldcar.BrandId = car.BrandId;
            db.SaveChanges();
        }


    }
}
