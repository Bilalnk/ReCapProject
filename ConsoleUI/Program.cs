using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {
            CarTest();
            BrandTest();
            // CarDtoTest();

            // InMemoryCarDal dal = new InMemoryCarDal();
            // Console.WriteLine("\n -----LinkTests");
            // dal.LinqSamples();
        }

        private static void CarDtoTest()
        {
            var manager = new CarManager(new EfCarDal());

            foreach (var detail in manager.GetCarDetails().Data)
            {
                Console.WriteLine(detail.CarId + " " + detail.Color + " " + detail.BrandName + " " +
                                  detail.Description);
            }
        }

        private static void BrandTest()
        {
            var manager = new BrandManager(new EfBrandDal());

            Console.WriteLine("All Data");
            foreach (var brand in manager.GetAll().Data)
            {
                Console.WriteLine(brand);
            }

            Console.WriteLine("Get brand as Id");
            var getBrandAsId = manager.Get(2);
            Console.WriteLine(getBrandAsId);

            Console.WriteLine("");
            var getBrandWithName = manager.GetByName("Megane");
            Console.WriteLine(getBrandWithName);
        }

        private static void CarTest()
        {
            var carManager = new CarManager(new EfCarDal());

            // foreach (var car in carManager.GetAll())
            // {
            //     Console.WriteLine(car);
            // }

            if (carManager.GetByModelYear(2202).Success)
            {
                var cars = carManager.GetByModelYear(2202).Data;

                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine(carManager.GetByModelYear(2202).Success + " " +
                                  carManager.GetByModelYear(2202).Message);
            }
        }
    }
}