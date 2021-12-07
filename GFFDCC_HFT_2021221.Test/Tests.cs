using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFFDCC_HFT_2021221.Logic;
using GFFDCC_HFT_2021221.Models;
using GFFDCC_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;

namespace GFFDCC_HFT_2021221.Test
{
    [TestFixture]
    public class Tests
    {
        private Mock<ICarRepository> mockCarRepo;
        private Mock<IBrandRepository> mockBrandRepo;
        private Mock<ICarDealershipRepository> mockCardealershipRepo;
        private CarLogic cLogic;
        private CarDealershipLogic cdLogic;
        private BrandLogic bLogic;
        private List<Car> cars;
        private List<Brand> brands;
        private List<CarDealership> cardealerships;
        [SetUp]
        public void Setup()
        {
            this.mockCardealershipRepo = new Mock<ICarDealershipRepository>(MockBehavior.Loose);
            this.mockBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            this.mockCarRepo = new Mock<ICarRepository>(MockBehavior.Loose);
            this.cLogic = new CarLogic(this.mockCarRepo.Object,this.mockCardealershipRepo.Object, this.mockBrandRepo.Object);
            this.cdLogic = new CarDealershipLogic(this.mockCarRepo.Object, this.mockCardealershipRepo.Object, this.mockBrandRepo.Object);
            this.bLogic = new BrandLogic(this.mockCarRepo.Object, this.mockCardealershipRepo.Object, this.mockBrandRepo.Object);


            this.cardealerships = new List<CarDealership>()
            {
                new CarDealership(){Id=1,Name="asdasd",Country="Hungary"},
                new CarDealership(){Id=2,Name="CardealershipTest2",Country="Romania"},
                new CarDealership(){Id=3,Name="Használtautók",Country="Slovakia"},
            };
            this.brands = new List<Brand>()
            {
                new Brand(){Id=1,Name="BrandTest1"},
                new Brand(){Id=2,Name="BrandTest2"},
                new Brand(){Id=3,Name="BrandTest3"},
                new Brand(){Id=4,Name="BrandTest4"},
            };
            this.cars = new List<Car>()
            {
                new Car(){Id=1, Model="Test1",BasePrice=5000,BrandId=1,CarDealershipID=2},
                new Car(){Id=2, Model="Test2",BasePrice=10000,BrandId=2,CarDealershipID=3},
                new Car(){Id=3, Model="Test3",BasePrice=15000,BrandId=3,CarDealershipID=3},
                new Car(){Id=4, Model="Test4",BasePrice=25000,BrandId=4,CarDealershipID=1},
                new Car(){Id=5, Model="Test5",BasePrice=20000,BrandId=1,CarDealershipID=1},
            };
            
            
        }
        [Test]
        public void GetAllCardealerships()
        {
            this.mockCardealershipRepo.Setup(x => x.ReadAll()).Returns(this.cardealerships.AsQueryable());
            var xy = this.cdLogic.GetAllCardealerships();

            Assert.That(xy.Count, Is.EqualTo(this.cardealerships.Count));
            Assert.That(xy, Is.EquivalentTo(this.cardealerships));
            Assert.That(xy.Select(x => x.Name), Does.Contain("asdasd"));

            this.mockCardealershipRepo.Verify(x => x.ReadAll(), Times.Once);
            this.mockCardealershipRepo.Verify(x => x.Read(It.IsAny<int>()), Times.Never);

        }
        [TestCase(2)]
        [TestCase(3)]
        public void GetOneCar(int id)
        {
            this.mockCarRepo.Setup(z => z.ReadAll()).Returns(this.cars.AsQueryable());
            this.mockCarRepo.Setup(z => z.Read(It.IsAny<int>())).Returns(this.cars[id]);

            var x = this.cLogic.Read(id);
            var y = this.cLogic.Read(id);
           
            Assert.That(x, Is.Not.Null);
            Assert.That(x, Is.SameAs(y));

            this.mockCarRepo.Verify(z => z.Read(It.IsAny<int>()), Times.Exactly(2));
            this.mockCarRepo.Verify(z => z.ReadAll(), Times.Never);
        }

        [Test]
        public void CreateCardealership()
        {
            this.mockCardealershipRepo.Setup(y => y.ReadAll()).Returns(this.cardealerships.AsQueryable());
            this.mockCardealershipRepo.Setup(y => y.Create(It.IsAny<CarDealership>())).Callback<CarDealership>((CarDealership cd) => this.cardealerships.Add(cd));
            int dealershipsCount = this.cardealerships.Count;
            var x = this.cdLogic.ReadAll();
            CarDealership newcd = new CarDealership()
            {
                Id = 4,
                Name = "teszt",
                Country = "TestLandia",
                Taxnumber="435323253"

            };
            this.cdLogic.Create(newcd);
            

            Assert.That(x.Count, Is.EqualTo(dealershipsCount + 1));
            Assert.That(newcd.Name, Is.EqualTo("teszt"));

            this.mockCardealershipRepo.Verify(y => y.Create(It.IsAny<CarDealership>()), Times.Once);
        }
        [TestCase(5000,"Citroen C6")]
        public void CreateCar(int price, string model)
        {
            this.mockCarRepo.Setup(y => y.ReadAll()).Returns(this.cars.AsQueryable());
            this.mockCarRepo.Setup(y => y.Create(It.IsAny<Car>())).Callback<Car>((Car c) => this.cars.Add(c));
            int carcount = this.cars.Count;
            var x = this.cLogic.ReadAll();
            Car newcar = new Car()
            {
                Id = 6,
                Model = model,
                BasePrice= price       
            };
            this.cLogic.Create(newcar);
            Assert.That(x.Count, Is.EqualTo(carcount + 1));
            Assert.That(newcar.Model, Is.EqualTo(model));
        }
        [Test]
        public void CreateBrand()
        {
            this.mockBrandRepo.Setup(y => y.ReadAll()).Returns(this.brands.AsQueryable());
            this.mockBrandRepo.Setup(y => y.Create(It.IsAny<Brand>())).Callback<Brand>((Brand b) => this.brands.Add(b));
            int brandcount = this.brands.Count;
            var x = this.bLogic.ReadAll();
            Brand mybrand = new Brand()
            {
                Id = brandcount + 1,
                Name= "MyBrand"
            };
            this.bLogic.Create(mybrand);
            Assert.That(x.Count, Is.EqualTo(brandcount + 1));
            Assert.That(mybrand.Name, Is.EqualTo("MyBrand"));
        }
        [Test]
        public void AVGPriceByBrandsTest()
        {           
            
            this.mockCarRepo.Setup(repo => repo.ReadAll()).Returns(this.cars.AsQueryable);
            this.mockBrandRepo.Setup(repo => repo.ReadAll()).Returns(this.brands.AsQueryable);
            this.mockCardealershipRepo.Setup(repo => repo.ReadAll()).Returns(this.cardealerships.AsQueryable);
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("BrandTest1", 12500),
                new KeyValuePair<string, double>("BrandTest2", 10000),
                new KeyValuePair<string, double>("BrandTest3", 15000),
                new KeyValuePair<string, double>("BrandTest4", 25000)
            };
            var testcars1 = this.cLogic.AVGPriceByBrands();
            Assert.That(testcars1, Is.EqualTo(expected));
        }
        [Test]
        public void CarsFromHasznaltautoTest()
        {
            this.mockCarRepo.Setup(repo => repo.ReadAll()).Returns(this.cars.AsQueryable);
            this.mockBrandRepo.Setup(repo => repo.ReadAll()).Returns(this.brands.AsQueryable);
            this.mockCardealershipRepo.Setup(repo => repo.ReadAll()).Returns(this.cardealerships.AsQueryable);
            var result = this.cLogic.CarsFromHasznaltauto();
            List<Car> testcars0 = new List<Car>()
            {
                new Car(){Id=2, Model="Test2",BasePrice=10000,BrandId=2,CarDealershipID=3},
                new Car(){Id=3, Model="Test3",BasePrice=15000,BrandId=3,CarDealershipID=3},
            };
            Assert.That(result, Is.EqualTo(testcars0));
        }
        [TestCase(6000)]
        public void AverageCarPriceByBrandsHigherThanTest(int minavg)
        {
            List<AveragePriceResult> expected = new List<AveragePriceResult>()
            {

                new AveragePriceResult() { Brand = "BrandTest1", Avgprice = 12500 },
                new AveragePriceResult() { Brand = "BrandTest2", Avgprice = 10000 },
                new AveragePriceResult() { Brand = "BrandTest3", Avgprice = 15000 },
                new AveragePriceResult() { Brand = "BrandTest4", Avgprice = 25000 },
            };
            this.mockCarRepo.Setup(repo => repo.ReadAll()).Returns(this.cars.AsQueryable);
            this.mockBrandRepo.Setup(repo => repo.ReadAll()).Returns(this.brands.AsQueryable);
            this.mockCardealershipRepo.Setup(repo => repo.ReadAll()).Returns(this.cardealerships.AsQueryable);
            var result = this.cLogic.AverageCarPriceByBrandsHigherThan(minavg);
            Assert.That(result, Is.EquivalentTo(expected));
        }
        [Test]
        public void BrandPopularityByCarsTest()
        {
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("BrandTest1", 2),
                new KeyValuePair<string, double>("BrandTest2", 1),
                new KeyValuePair<string, double>("BrandTest3", 1),
                new KeyValuePair<string, double>("BrandTest4", 1)
            };
            this.mockCarRepo.Setup(repo => repo.ReadAll()).Returns(this.cars.AsQueryable);
            this.mockBrandRepo.Setup(repo => repo.ReadAll()).Returns(this.brands.AsQueryable);
            var result = this.cLogic.BrandPopularityByCars();

           Assert.That(result, Is.EquivalentTo(expected));
        }
        [TestCase("Hungary")]
        public void CarsByCountryTest(string countryCars)
        {
            List<Car> newlist = new List<Car>()
            {
                new Car(){Id=4, Model="Test4",BasePrice=25000,BrandId=4,CarDealershipID=1},
                new Car(){Id=5, Model="Test5",BasePrice=20000,BrandId=1,CarDealershipID=1}
            };
            this.mockCarRepo.Setup(repo => repo.ReadAll()).Returns(this.cars.AsQueryable);
            this.mockBrandRepo.Setup(repo => repo.ReadAll()).Returns(this.brands.AsQueryable);
            this.mockCardealershipRepo.Setup(repo => repo.ReadAll()).Returns(this.cardealerships.AsQueryable);
            var result = this.cLogic.CarsByCountry(countryCars);
            Assert.That(result, Is.EqualTo(newlist));
        }
    }
}
