using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
            //if (DateTime.Now.Hour == 21)
            //{
            //    return new ErrorDataResult<List<Car>>("Bakımda ");
            //}

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByModelYear(int year)
        {
            var result = _carDal.GetAll(car => car.ModelYear == year);

            if (result == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car => car.Id == carId));
        }

        public IResult DeleteById(int id)
        {
            var res = isCarExist(id);
            if (res == null) return new ErrorResult(Messages.NotFound);
            _carDal.Delete(res);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Car car)
        {
            var res = isCarExist(car.Id);
            if (res == null) return new ErrorResult(Messages.NotFound);

            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        private Car isCarExist(int id)
        {
            var result = _carDal.Get(car => car.Id == id);
            return result;
        }
    }
}