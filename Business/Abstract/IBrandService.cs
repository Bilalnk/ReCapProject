using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();

        IDataResult<Brand> GetById(int id);

        IDataResult<Brand> GetByName(string name);

        IResult Add(Brand brand);

        IResult DeleteById(int id);

        IResult Update(Brand brand);

        IDataResult<Brand> Get(int id);
    }
}