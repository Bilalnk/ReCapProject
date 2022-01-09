using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int categoryId)
        {
            return _brandDal.Get(c => c.id == categoryId);
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(brand => brand.id == id);
        }
    }
}