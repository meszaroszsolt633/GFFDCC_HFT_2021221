using GFFDCC_HFT_2021221.Data;
using GFFDCC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Client
{
    public class Menu
    {
        private static CarDbContext ctx = new CarDbContext();
        private static CarRepository carRepo = new CarRepository(ctx);
        private static BrandRepository brandRepo = new BrandRepository(ctx);
        private static CarDealershipRepository cardRepo = new CarDealershipRepository(ctx);
        public Menu()
        {
            this.carMenu = new MenuMain(carRepo, brandRepo, cardRepo);
        }
        public MenuMain carMenu { get; set; }
    }
}
