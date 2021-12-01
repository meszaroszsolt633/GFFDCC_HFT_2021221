using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Models;
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
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    Console.WriteLine(this.CLogic.Read(id).ToString());
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }

            Console.ReadLine();
        }
        public void CreateCar()
        {
            List<bool> inputs = new List<bool>();
            Console.WriteLine("Model name:");
            string model = Console.ReadLine();
            Console.WriteLine("Base price:");
            inputs.Add(int.TryParse(Console.ReadLine(), out int price));
            Console.WriteLine("Brand ID:");
            inputs.Add(int.TryParse(Console.ReadLine(), out int brandid));
            Console.WriteLine("Cardealership ID:");
            inputs.Add(int.TryParse(Console.ReadLine(), out int cdid));
            bool success = true;
            foreach (bool item in inputs)
            {
                if (!item)
                {
                    success = false;
                }
            }

            if (success)
            {
                Car tmp = new Car() { Model = model, BasePrice = price, BrandId = brandid, CarDealershipID = cdid };

                try
                {
                    this.CLogic.Create(tmp);
                    Console.WriteLine("Car created");
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }

            Console.ReadLine();

        }
        public void DeleteCar()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    this.CLogic.Delete(id);
                    Console.WriteLine("Succesful");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }

            Console.ReadLine();
        }
        public void UpdateCarModel()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    Console.WriteLine("Current Model: " + this.CLogic.Read(id).Model);
                    Console.WriteLine("New Model:");
                    string newModel = Console.ReadLine();
                    Car tmp = this.CLogic.Read(id);
                    tmp.Model = newModel;
                    this.CLogic.Update(tmp);
                    Console.WriteLine("Model changed");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }

            Console.ReadLine();

        }
        public void UpdateCarPrice()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    Console.WriteLine("Current Price: " + this.CLogic.Read(id).BasePrice);
                    Console.WriteLine("New Price:");
                    if (int.TryParse(Console.ReadLine(), out int newPrice))
                    {
                        Car tmp = this.CLogic.Read(id);
                        tmp.BasePrice = newPrice;
                        this.CLogic.Update(tmp);
                        Console.WriteLine("Price changed");
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");
                    }
                    

                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }

            Console.ReadLine();
        }
    }
}
