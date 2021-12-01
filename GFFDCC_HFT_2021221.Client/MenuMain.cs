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
                Add("Brands", () => this.CreateBrandMenu()).
                Add("Statistics", () => this.CreateStatisticsMenu()).
                Add("Close", ConsoleMenu.Close);
        }
        private void CreateCarMenu()
        {
            this.CarMenu = new ConsoleMenu().
                 Add("Read all Car", () => this.CMenu.ReadAllCar()).
                 Add("Read one Car", () => this.CMenu.ReadOneCar()).
                 Add("Add Car", () => this.CMenu.AddCar()).
                 Add("Delete Car", () => this.CMenu.DeleteCar()).
                 Add("ChangeCarName", () => this.CMenu.ChangeCarModel()).
                Add("ChangeCarPrice", () => this.CMenu.ChangeCarPrice()).
                Add("Close", ConsoleMenu.Close);
            this.CarMenu.Show();
        }
        private void CreateBrandMenu()
        {

        }
        private void CreateStatisticsMenu()
        {

        }
    }
}
