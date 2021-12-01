using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Client.Menus
{
    public class Carmenus
    {
        public Carmenus(ICarRepository carRepo, IBrandRepository brandRepo, ICarDealershipRepository cardRepo)
        {
            this.CLogic = new CarLogic(carRepo, cardRepo, brandRepo);
        }
        public CarLogic CLogic { get; set; }
        public void ReadAllCar()
        {
            foreach (var item in this.CLogic.ReadAll())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        public void ReadOneCar()
        {

        }
        public void AddCar()
        {

        }
        public void DeleteCar()
        {

        }
        public void ChangeCarModel()
        {

        }
        public void ChangeCarPrice()
        {

        }
    }
}
