using CarDB.Client;
using GFFDCC_HFT_2021221.Models;
using System;


namespace GFFDCC_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:5822");
            var brands = rest.Get<Brand>("brand");
            ;
        }
    }
}
