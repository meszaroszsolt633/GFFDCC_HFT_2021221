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


            this.cardealerships = new List<CarDealership>()
            {
                new CarDealership(){Id=1,Name="asdasd"},
                new CarDealership(){Id=2,Name="CardealershipTest2"},
                new CarDealership(){Id=3,Name="CardealershipTest3"},
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
                new Car(){Id=1, Model="Test1"},
                new Car(){Id=2, Model="Test2"},
                new Car(){Id=3, Model="Test3"},
                new Car(){Id=4, Model="Test4"},
                new Car(){Id=5, Model="Test5"},
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
        [TestCase(2,"test1")]
        [TestCase(3,"test322132")]
        public void ChangeCarModel(int id, string newName)
        {
            Car testCar = this.cLogic.Read(id);
            testCar.Model = newName;


            this.mockCarRepo.Setup(repo => repo.ReadAll()).Returns(this.cars.AsQueryable());
            this.mockCarRepo.Setup(repo => repo.Read(It.IsAny<int>())).Returns(this.cars[id]);
            this.mockCarRepo.Setup(repo => repo.Update(testCar));
            this.cLogic.Update(testCar);

            Assert.That(this.cLogic.Read(id).Model, Is.EqualTo(newName));
            this.mockCarRepo.Verify(repo => repo.Read(id), Times.Once);
        }
        [Test]
        public void InsertCardealership()
        {
            int dealershipsCount = this.cardealerships.Count;
            this.mockCardealershipRepo.Setup(repo => repo.ReadAll()).Returns(this.cardealerships.AsQueryable());
            this.mockCardealershipRepo.Setup(repo => repo.Create(It.IsAny<CarDealership>())).Callback<CarDealership>((CarDealership p) => this.cardealerships.Add(p));
            this.cdLogic.Create(new CarDealership() { Id = 4, Name = "Teszt KFT." });
            var x = this.cdLogic.ReadAll();

            Assert.That(x.Count, Is.EqualTo(dealershipsCount + 1));

            this.mockCardealershipRepo.Verify(repo => repo.Create(It.IsAny<CarDealership>()), Times.Once);
            this.mockCardealershipRepo.Verify(repo => repo.ReadAll(), Times.Once);
            this.mockCardealershipRepo.Verify(repo => repo.ReadAll(), Times.Never);
        }

    }
}
