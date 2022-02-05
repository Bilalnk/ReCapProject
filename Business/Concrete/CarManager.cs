using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>("Bakımda ");
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByModelYear(int year)
        {
            var result = _carDal.GetAll(car => car.ModelYear == year);
            // Console.WriteLine(result);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>("Yok", null);
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 5)
            {
                return new ErrorResult(Messages.ShortDescription);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car => car.Id == carId));
        }
    }
}