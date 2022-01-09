using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();

        Brand GetById(int categoryId);

        Brand Get(int id);
    }
}