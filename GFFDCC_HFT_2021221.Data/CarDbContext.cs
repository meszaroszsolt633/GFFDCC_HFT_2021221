﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFFDCC_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace GFFDCC_HFT_2021221.Data
{
    public class CarDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }     
        public virtual DbSet<CarDealership> CarDealerships { get; set; }
        public CarDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDatabase.mdf;Integrated Security = True; MultipleActiveResultSets = True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                .HasOne(cars => cars.CarDealership)            
                .WithMany(cardealerships => cardealerships.Carsatstock)
                .HasForeignKey(cars => cars.CarDealershipID)
                .OnDelete(DeleteBehavior.Cascade);
                entity
                .HasOne(cars => cars.Brand)
                .WithMany(brands => brands.Cars)
                .HasForeignKey(cars => cars.BrandId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            //modelbuilder.entity<car>(entity =>
            //{
            //    entity
            //    .hasone(cars => cars.brand)
            //    .withmany(brands => brands.cars)
            //    .hasforeignkey(cars => cars.brandid)
            //    .ondelete(deletebehavior.restrict);
            //});

            Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand citroen = new Brand() { Id = 2, Name = "Citroen" };
            Brand audi = new Brand() { Id = 3, Name = "Audi" };
            Brand volkswagen = new Brand() { Id = 4, Name = "Volkswagen" };
            Brand skoda = new Brand() { Id = 5, Name = "Skoda" };

            CarDealership zsolczai = new CarDealership() { Id = 1, Name = "Zsolczai",Country="Slovakia",Taxnumber= "4932428556" };
            CarDealership dudi = new CarDealership() { Id = 2, Name = "Dudi",Country="Romania",Taxnumber= "2176338546" };
            CarDealership hasznaltautohu = new CarDealership() { Id = 3, Name = "Használtautók", Country = "Hungary", Taxnumber = "5436637546" };

            Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 18000, Model = "BMW 116d", CarDealershipID=hasznaltautohu.Id};
            Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 16000, Model = "BMW 510", CarDealershipID = hasznaltautohu.Id };
            Car citroen1 = new Car() { Id = 3, BrandId = citroen.Id, BasePrice = 12000, Model = "Citroen C1", CarDealershipID = hasznaltautohu.Id };
            Car citroen2 = new Car() { Id = 4, BrandId = citroen.Id, BasePrice = 9500, Model = "Citroen C3", CarDealershipID = hasznaltautohu.Id };
            Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 7800, Model = "Audi A3", CarDealershipID = hasznaltautohu.Id };
            Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 6000, Model = "Audi A4", CarDealershipID = hasznaltautohu.Id };
            Car volkswagen1 = new Car() { Id = 7, BrandId = volkswagen.Id, BasePrice = 4000, Model = "Volkswagen Golf4", CarDealershipID = hasznaltautohu.Id };
            Car volkswagen2 = new Car() { Id = 8, BrandId = volkswagen.Id, BasePrice = 3500, Model = "Volkswagen Passat1.8", CarDealershipID = hasznaltautohu.Id };
            Car skoda1 = new Car() { Id = 9, BrandId = skoda.Id, BasePrice = 3000, Model = "Skoda Octavia1.4", CarDealershipID = hasznaltautohu.Id };
            Car skoda2 = new Car() { Id = 10, BrandId = skoda.Id, BasePrice = 1800, Model = "Skoda Fabia1.4", CarDealershipID = hasznaltautohu.Id };

            modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi, volkswagen,skoda);
            modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2, volkswagen1, volkswagen2,skoda1,skoda2);
            modelBuilder.Entity<CarDealership>().HasData(zsolczai, dudi, hasznaltautohu);
        }

    }
}
