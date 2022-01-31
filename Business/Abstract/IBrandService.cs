using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();

        IDataResult<Brand> GetById(int categoryId);

        IDataResult<Brand> Get(int id);
    }
}