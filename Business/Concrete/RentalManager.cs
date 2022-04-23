using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result == null) return new ErrorDataResult<List<Rental>>(Messages.NoData);
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(rental => rental.Id == id);
            if (result == null) return new ErrorDataResult<Rental>(Messages.NoData);
            return new SuccessDataResult<Rental>(result);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            var result = _rentalDal.GetAll(rental => rental.CarId == carId);
            if (result == null) return new ErrorDataResult<List<Rental>>(Messages.NoData);
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            var result = _rentalDal.GetAll(rental => rental.CustomerId.Equals(customerId));
            if (result == null) return new ErrorDataResult<List<Rental>>(Messages.NoData);
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.Get(rent => rent.Id.Equals(rent.Id));
            if (result == null) return new ErrorDataResult<List<Rental>>(Messages.NoData);
            _rentalDal.Delete(rental);
            return new SuccessDataResult<Rental>(result.Id + Messages.Deleted);
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(rent => rent.Id.Equals(rental.Id));
            if (result == null) return new ErrorDataResult<List<Rental>>(Messages.NoData);
            _rentalDal.Update(rental);
            return new SuccessDataResult<Rental>(result + Messages.Updated + " to " +
                                                 _rentalDal.Get(rent => rent.Id.Equals(rental.Id)));
        }
    }
}