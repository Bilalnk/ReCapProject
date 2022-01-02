using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;
        private List<CarColor> _colors;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id = "1", ModelYear = DateTime.Now.Year, Description = "this is a description", DailyPrice = 50,
                    BrandId = "2", ColorId = "5"
                },
                new Car
                {
                    Id = "3", ModelYear = DateTime.Now.Year, Description = "this is not a description",
                    DailyPrice = 150, BrandId = "4", ColorId = "7"
                },
                new Car
                {
                    Id = "2", ModelYear = DateTime.Now.Year, Description = "this is a other description",
                    DailyPrice = 250, BrandId = "3", ColorId = "6"
                },
                new Car
                {
                    Id = "4", ModelYear = DateTime.Now.Year, Description = "this is different description",
                    DailyPrice = 40, BrandId = "5", ColorId = "8"
                }
            };

            _colors = new List<CarColor>
            {
                new CarColor {Id = "5", ColorName = "Mavi"},
                new CarColor {Id = "8", ColorName = "Kırmızı"},
                new CarColor {Id = "6", ColorName = "Beyaz"},
                new CarColor {Id = "7", ColorName = "Siyah"}
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(string id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(currentCar => currentCar.Id == car.Id);
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id); //singleOrdefault -> sadece bir tane arar
            _cars.Remove(carToDelete);
        }

        public void LinqSamples()
        {
            //Any
            var result = _cars.Any(car => car.ModelYear == 2022);
            Console.WriteLine(result + "\n");

            //Find
            var result2 = _cars.Find(car => car.Id == "3");
            Console.WriteLine(result2 + "\n");

            //FindAll
            var result3 = _cars.FindAll(car => car.Description.Contains("is"));
            Console.WriteLine(result3 + "\n");

            //where
            var result4 = _cars.Where(car => car.Description.Contains("is"));
            foreach (var car in result4)
            {
                Console.WriteLine(car);
            }

            //where asc dsc
            var result5 = _cars.Where(car => car.Description.Contains("is")).OrderByDescending(car => car.Id)
                .ThenBy(car => car.ColorId);
            foreach (var car in result5)
            {
                Console.WriteLine(car);
            }

            //other queries
            var result6 = from c in _cars
                where c.Description.Contains("this")
                orderby c.Id descending, c.BrandId
                select c;
            foreach (var car in result6)
            {
                Console.WriteLine(car.ToString());
            }

            ///// JOIN ///////

            //other queries
            var result7 = from c in _cars
                join col in _colors on c.ColorId equals col.Id
                where c.Description.Contains("is")
                orderby c.Id descending 
                select new CarDto {CarId = c.Id, CarDescription = c.Description, ColorName = col.ColorName};

            foreach (var car in result7)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }

    public class CarDto
    {
        public string CarId { get; set; }
        public string ColorName { get; set; }
        public string CarDescription { get; set; }

        public override string ToString()
        {
            return CarId +" "+ ColorName +" "+ CarDescription;
        }
    }
}