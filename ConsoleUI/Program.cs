using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {
            /*
            CarTest();
            BrandTest();
            */
            CarDtoTest();

            // InMemoryCarDal dal = new InMemoryCarDal();
            // Console.WriteLine("\n -----LinkTests");
            // dal.LinqSamples();
        }

        private static void CarDtoTest()
        {
            var manager = new CarManager(new EfCarDal());

            foreach (var detail in manager.GetCarDetails())
            {
                Console.WriteLine(detail.CarId + " " + detail.Color + " " + detail.BrandName + " " +
                                  detail.Description);
            }
        }

        private static void BrandTest()
        {
            var manager = new BrandManager(new EfBrandDal());

            foreach (var brand in manager.GetAll())
            {
                Console.WriteLine(brand);
            }

            var getBrandAsId = manager.Get(2);
            Console.WriteLine(getBrandAsId);
        }

        private static void CarTest()
        {
            var carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car);
            }
        }
    }
}