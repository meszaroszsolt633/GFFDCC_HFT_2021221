using GFFDCC_HFT_2021221.Data;
using GFFDCC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Repository
{
    public class BrandRepository : IBrandRepository
    {
        CarDbContext db;
        public BrandRepository(CarDbContext db)
        {
            this.db = db;
        }
        public void Create(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
        }
        public Brand Read(int id)
        {
            return db.Brands.FirstOrDefault(t => t.Id == id);
        }
        public IQueryable<Brand> ReadAll()
        {
            return db.Brands;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Brand brand)
        {
            var oldBrand = Read(brand.Id);
            oldBrand.Name = brand.Name;
            db.SaveChanges();
        }
    }
}
