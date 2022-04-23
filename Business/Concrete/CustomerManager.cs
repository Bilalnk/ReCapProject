using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result.Count == 0) return new ErrorDataResult<List<Customer>>(Messages.NoData);
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IResult Add(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);
            }

            return new ErrorResult(Messages.InvalidParameter);
        }

        public IResult DeleteById(int id)
        {
            var result = _customerDal.Get(customer => customer.UserId == id);
            if (result == null) return new SuccessDataResult<User>(Messages.NoData);
            _customerDal.Delete(result);
            return new SuccessDataResult<User>(Messages.Deleted + " : " + result);
        }

        public IResult Update(Customer customer)
        {
            var result = _customerDal.Get(u => u.Id == customer.Id);
            if (result == null) return new SuccessDataResult<User>(Messages.NoData);
            _customerDal.Update(customer);
            return new SuccessDataResult<User>(Messages.Updated);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(user => user.UserId == id);
            if (result == null) return new SuccessDataResult<Customer>(Messages.NoData);
            return new SuccessDataResult<Customer>(result);
        }
    }
}