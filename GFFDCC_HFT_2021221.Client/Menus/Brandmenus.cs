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
    public class Brandmenus
    {
        public Brandmenus(ICarRepository carRepo, IBrandRepository brandRepo, ICarDealershipRepository cardRepo)
        {
            this.BLogic = new BrandLogic(carRepo, cardRepo, brandRepo);
            this.CdLogic = new CarDealershipLogic(carRepo, cardRepo, brandRepo);
        }
        private BrandLogic BLogic { get; set; }
        private CarDealershipLogic CdLogic { get; set; }
        public void ReadAllBrand()
        {
            foreach (var item in this.BLogic.ReadAll())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        public void ReadAllCardealership()
        {
            foreach (var item in this.CdLogic.ReadAll())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        public void ReadOneBrand()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    Console.WriteLine(this.BLogic.Read(id).ToString());
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
        public void ReadOneCardealership()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    Console.WriteLine(this.CdLogic.Read(id).ToString());
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
        public void CreateBrand()
        {
            Console.WriteLine("Brand name:");
            string brandname = Console.ReadLine();
            bool success = true;
            if (success)
            {
                Brand tmp = new Brand() { Name = brandname };

                try
                {
                    this.BLogic.Create(tmp);
                    Console.WriteLine("Brand created");
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
        public void CreateCardealership()
        {
            List<bool> parses = new List<bool>();
            Console.WriteLine("Cardealership name:");
            string cdname = Console.ReadLine();
            Console.WriteLine("Country:");
            string country = Console.ReadLine();
            Console.WriteLine("TaxNumber:");
            string taxnumber = Console.ReadLine();
            bool success = true;
            foreach (bool item in parses)
            {
                if (!item)
                {
                    success = false;
                }
            }   
            if (success)
            {
                CarDealership tmp = new CarDealership() { Name= cdname, Country=country,Taxnumber=taxnumber};

                try
                {
                    this.CdLogic.Create(tmp);
                    Console.WriteLine("Cardealership created");
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
        public void DeleteBrand()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    this.BLogic.Delete(id);
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
        public void DeleteCardealership()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    this.CdLogic.Delete(id);
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
        public void UpdateDealershipCountry()
        {
            Console.WriteLine("Enter the ID");
            bool input = int.TryParse(Console.ReadLine(), out int id);
            if (input)
            {
                try
                {
                    Console.WriteLine("Current Country: " + this.CdLogic.Read(id).Country);
                    Console.WriteLine("New Country:");
                    string newCountry = Console.ReadLine();
                    CarDealership tmp = this.CdLogic.Read(id);
                    tmp.Country = newCountry;
                    this.CdLogic.Update(tmp);
                    Console.WriteLine("Country changed");


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
