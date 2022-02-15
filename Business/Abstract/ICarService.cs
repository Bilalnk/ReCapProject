using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetByModelYear(int year);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car car);
        IDataResult<Car> GetById(int carId);
        IResult DeleteById(int id);
        IResult Update(Car car);
    }
}