using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            if (id < 1) return new ErrorDataResult<Brand>(Messages.InvalidParameter);

            var result = _brandDal.Get(c => c.id == id);

            if (result == null) return new ErrorDataResult<Brand>(Messages.NotFound);

            return new SuccessDataResult<Brand>(result);
        }

        public IDataResult<Brand> GetByName(string name)
        {
            if (!isBrandExist(default, name)) return new ErrorDataResult<Brand>(Messages.NotFound);
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.Name.Equals(name)));
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Equals(null) || brand.Name.Equals("") || brand.Name.Equals(" "))
            {
                return new ErrorResult(Messages.BrandNameNotNull);
            }

            if (isBrandExist(default, brand.Name))
            {
                return new ErrorResult(Messages.ExistData);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult DeleteById(int id)
        {
            Brand brand = _brandDal.Get(brand1 => brand1.id == id);
            if (brand == null) return new ErrorResult(Messages.NotFound);

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Brand brand)
        {
            if (!isBrandExist(brand.id))
            {
                return new ErrorResult(Messages.NotFound);
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated + " " + brand.id + " " + brand.Name);
        }

        public IDataResult<Brand> Get(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.id == id));
        }

        public bool isBrandExist(int id = -1, string name = null)
        {
            Brand existBrand = null;
            if (name != null) existBrand = _brandDal.Get(brand1 => brand1.Name == name);
            else if (id != -1) existBrand = _brandDal.Get(brand1 => brand1.id == id);

            return existBrand != null;
        }
    }
}