using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFFDCC_HFT_2021221.Repository;
using ConsoleTools;
using GFFDCC_HFT_2021221.Client.Menus;

namespace GFFDCC_HFT_2021221.Client
{
    public class MenuMain
    {
        public MenuMain(ICarRepository carRepo, IBrandRepository brandRepo, ICarDealershipRepository cardRepo)
        {
            this.CMenu = new Carmenus(carRepo, brandRepo, cardRepo);
            this.BMenu = new Brandmenus(carRepo, brandRepo, cardRepo);
            this.SMenu = new Statisticsmenus(carRepo, brandRepo, cardRepo);
        }
        public Carmenus CMenu { get; set; }
        public Brandmenus BMenu { get; set; }
        public Statisticsmenus SMenu { get; set; }

        public ConsoleMenu ConsoleMenu { get; set; }
        public ConsoleMenu CarMenu { get; set; }
        public ConsoleMenu BrandMenu { get; set; }
        public ConsoleMenu StatisticsMenu { get; set; }
        public void CreateMainMenu()
        {
            this.ConsoleMenu = new ConsoleMenu().
                Add("Cars", () => this.CreateCarMenu()).
                Add("Brands", () => this.CreateBrandAndDealershipMenu()).
                Add("Statistics", () => this.CreateStatisticsMenu()).
                Add("Close", ConsoleMenu.Close);
        }
        private void CreateCarMenu()
        {
            this.CarMenu = new ConsoleMenu().
                 Add("Read all Car", () => this.CMenu.ReadAllCar()).
                 Add("Read one Car", () => this.CMenu.ReadOneCar()).
                 Add("Update Car Model", () => this.CMenu.UpdateCarModel()).
                 Add("Update Car Price", () => this.CMenu.UpdateCarPrice()).
                 Add("Create Car", () => this.CMenu.CreateCar()).
                 Add("Delete Car", () => this.CMenu.DeleteCar()).                
                 Add("Close", ConsoleMenu.Close);
            this.CarMenu.Show();
        }
        private void CreateBrandAndDealershipMenu()
        {
            this.BrandMenu = new ConsoleMenu().
                Add("Read all Brand", () => this.BMenu.ReadAllBrand()).
                Add("Read all Cardealership", () => this.BMenu.ReadAllCardealership()).
                Add("Read one Brand", () => this.BMenu.ReadOneBrand()).
                Add("Read one Cardealership", () => this.BMenu.ReadOneCardealership()).
                Add("Create Brand", () => this.BMenu.CreateBrand()).
                Add("Create Cardealership", () => this.BMenu.CreateCardealership()).
                Add("Delete Brand", () => this.BMenu.DeleteBrand()).
                Add("Delete Cardealership", () => this.BMenu.DeleteCardealership()).
                Add("Update Cardealership Country", () => this.BMenu.UpdateDealershipCountry()).
                Add("Close", ConsoleMenu.Close);
            this.BrandMenu.Show();
        }
        private void CreateStatisticsMenu()
        {
            this.StatisticsMenu = new ConsoleMenu().
                Add("Average price results higher than", () => this.SMenu.AverageCarPriceByBrandsHigherThan()).
                Add("Cars by country", () => this.SMenu.CarsByCountry()).
                Add("Brand popularity by cars", () => this.SMenu.BrandPopularityByCars()).
                Add("Cars from hasznaltauto", () => this.SMenu.CarsFromHasznaltauto()).
                Add("Average prices by brands", () => this.SMenu.AVGPriceByBrands()).
                Add("Close", ConsoleMenu.Close);
            this.StatisticsMenu.Show();
        }
    }
}
