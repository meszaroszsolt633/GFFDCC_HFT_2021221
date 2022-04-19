using GFFDCC_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace GFFDCC_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<CarDealership> CarDealerships { get; set; }
        private Car selectedCar;
        private Brand selectedBrand;
        private CarDealership selectedCarDealership;
        private string carnameFieldContent;
        public string CarnameFieldContent
        {
            get { return carnameFieldContent; }
            set{
                SetProperty(ref carnameFieldContent, value);
                (CreateCarCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateCarCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if(value!=null)
                {
                    selectedCar = new Car()
                    {
                        Model = value.Model,
                        BasePrice=value.BasePrice,
                        Brand=value.Brand,
                        CarDealership=value.CarDealership,
                        BrandId=value.BrandId,
                        CarDealershipID=value.CarDealershipID,
                        Id=value.Id

                    };
                    SetProperty(ref selectedCar, value);
                    (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                    CarnameFieldContent = selectedCar.Model;
                }
                
            }
        }
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name=value.Name,
                        Cars=value.Cars,
                        Id=value.Id

                    };
                    SetProperty(ref selectedBrand, value);
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }
        public CarDealership SelectedCarDealership
        {
            get { return selectedCarDealership; }
            set
            {
                if (value != null)
                {
                    selectedCarDealership = new CarDealership()
                    {
                        Name=value.Name,
                        Country=value.Country,
                        Taxnumber=value.Taxnumber,
                        Carsatstock=value.Carsatstock,
                        Id=value.Id

                    };
                    SetProperty(ref selectedCarDealership, value);
                    (DeleteCarDealershipCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }
        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        public ICommand CreateCarDealershipCommand { get; set; }
        public ICommand DeleteCarDealershipCommand { get; set; }
        public ICommand UpdateCarDealershipCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:5822/", "car","hub");
                Brands = new RestCollection<Brand>("http://localhost:5822/", "brand", "hub");
                CarDealerships = new RestCollection<CarDealership>("http://localhost:5822/", "cardealership", "hub");
                //car
                CreateCarCommand = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                        Model = CarnameFieldContent,
                        BasePrice=SelectedCar.BasePrice,
                        Brand=SelectedCar.Brand,
                        CarDealership = SelectedCar.CarDealership,
                        BrandId =SelectedCar.BrandId,
                        CarDealershipID=SelectedCar.CarDealershipID
                    }) ;
                }
                );

                DeleteCarCommand = new RelayCommand(() =>
                 {
                     Cars.Delete(SelectedCar.Id);
                 },
                 () =>
                 {
                     return SelectedCar != null;
                 }

                 );

                UpdateCarCommand = new RelayCommand(() =>
                {
                    SelectedCar.Model = CarnameFieldContent;
                    Cars.Update(SelectedCar);
                });

                //brand

                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name=SelectedBrand.Name,
                        Cars=SelectedBrand.Cars
                    });
                }
                );

                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.Id);
                },
                 () =>
                 {
                     return SelectedBrand != null;
                 }

                 );

                UpdateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Update(SelectedBrand);
                });
                

                //cardealership

                CreateCarDealershipCommand = new RelayCommand(() =>
                {
                    CarDealerships.Add(new CarDealership()
                    {
                        Name=SelectedCarDealership.Name,
                        Country=SelectedCarDealership.Country,
                        Taxnumber = SelectedCarDealership.Taxnumber,
                        Carsatstock = SelectedCarDealership.Carsatstock
                    });
                }
                );

                DeleteCarDealershipCommand = new RelayCommand(() =>
                {
                    CarDealerships.Delete(SelectedCarDealership.Id);
                },
                 () =>
                 {
                     return SelectedCarDealership != null;
                 }

                 );

                UpdateCarDealershipCommand = new RelayCommand(() =>
                {
                    CarDealerships.Update(SelectedCarDealership);
                });
                SelectedCar = new Car();
                SelectedBrand = new Brand();
                SelectedCarDealership = new CarDealership();

            }
            
        }
    }
}
