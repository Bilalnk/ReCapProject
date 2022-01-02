using System.Collections.Generic;
using Entities;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetById(string id);
        void Add(Car car);
        void Update(Car car);
        void Delete (Car car);
    }
}