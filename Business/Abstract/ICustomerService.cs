using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer customer);
        IResult DeleteById(int id);
        IResult Update(Customer customer);
        IDataResult<Customer> GetById(int id);
    }
}