﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFFDCC_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace GFFDCC_HFT_2021221.Data
{
    class CarDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }     
        public virtual DbSet<CarDealership> CarDealerships { get; set; }
        public CarDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\razor\\source\\repos\\GFFDCC_HFT_2021221\\GFFDCC_HFT_2021221.Data\\Database1.mdf\"; Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand citroen = new Brand() { Id = 2, Name = "Citroen" };
            Brand audi = new Brand() { Id = 3, Name = "Audi" };
            Brand volkswagen = new Brand() { Id = 4, Name = "Volkswagen" };
            Brand skoda = new Brand() { Id = 5, Name = "Skoda" };

            Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW 116d" };
            Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 30000, Model = "BMW 510" };
            Car citroen1 = new Car() { Id = 3, BrandId = citroen.Id, BasePrice = 10000, Model = "Citroen C1" };
            Car citroen2 = new Car() { Id = 4, BrandId = citroen.Id, BasePrice = 15000, Model = "Citroen C3" };
            Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 20000, Model = "Audi A3" };
            Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 25000, Model = "Audi A4" };
            Car volkswagen1 = new Car() { Id = 7, BrandId = volkswagen.Id, BasePrice = 4000, Model = "Volkswagen Golf4" };
            Car volkswagen2 = new Car() { Id = 8, BrandId = volkswagen.Id, BasePrice = 3500, Model = "Volkswagen Passat1.8" };
            Car skoda1 = new Car() { Id = 9, BrandId = skoda.Id, BasePrice = 3000, Model = "Skoda Octavia1.4" };
            Car skoda2 = new Car() { Id = 10, BrandId = skoda.Id, BasePrice = 1800, Model = "Skoda Fabia1.4" };

            modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi, volkswagen,skoda);
            modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2, volkswagen1, volkswagen2,skoda1,skoda2);
        }

    }
}
