using GFFDCC_HFT_2021221.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using GFFDCC_HFT_2021221.Repository;

namespace GFFDCC_HFT_2021221.Test
{
    [TestFixture]
    public class NonCRUDTESTS
    {
        private Mock<ICarRepository> mockCarRepo;
        private Mock<IBrandRepository> mockBrandRepo;
        private Mock<ICarDealershipRepository> mockCardealershipRepo;
        private List<Car> cars;
        private List<Brand> brands;
        private List<CarDealership> cardealerships;
        [SetUp]
        public void Setup()
        {
            this.mockCardealershipRepo = new Mock<ICarDealershipRepository>(MockBehavior.Loose);
            this.mockBrandRepo= new Mock<IBrandRepository>(MockBehavior.Loose);
            this.mockCarRepo = new Mock<ICarRepository>(MockBehavior.Loose);


            this.cars = new List<Car>()
            {
                new Car(){Id=1, Model="Test1"},
                new Car(){Id=2, Model="Test2"},
                new Car(){Id=3, Model="Test3"},
                new Car(){Id=4, Model="Test4"},
                new Car(){Id=5, Model="Test5"},
            };
            this.brands = new List<Brand>()
            {
                new Brand(){Id=1,Name="BrandTest1"},
                new Brand(){Id=2,Name="BrandTest2"},
                new Brand(){Id=3,Name="BrandTest3"},
                new Brand(){Id=4,Name="BrandTest4"},
            };
            this.cardealerships = new List<CarDealership>()
            {
                new CarDealership(){Id=1,Name="CardealershipTest1"},
                new CarDealership(){Id=2,Name="CardealershipTest2"},
                new CarDealership(){Id=3,Name="CardealershipTest3"},
            };
        }


    }
}
