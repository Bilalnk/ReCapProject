using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<Brand> GetById(int id)
        {
            if (id < 1) return new ErrorDataResult<Brand>(Messages.InvalidParameter);

            var result = _brandDal.Get(c => c.id == id);

            if (result == null) return new ErrorDataResult<Brand>(Messages.NotFound);

            return new SuccessDataResult<Brand>(result);
        }

        public IDataResult<Brand> GetByName(string name)
        {
            IResult result = BusinessRules.Run(isBrandExist(default, name));
            if (!result.Success)
            {
                return new ErrorDataResult<Brand>(result.Message);
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.Name.Equals(name)));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(isBrandExist(default, brand.Name));
            if (!result.Success)
            {
                return result;
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
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
            IResult result = BusinessRules.Run(isBrandExist(default, brand.Name));
            if (!result.Success)
            {
                return result;
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated + " " + brand.id + " " + brand.Name);
        }

        public IDataResult<Brand> Get(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.id == id));
        }

        public IResult isBrandExist(int id = -1, string name = null)
        {
            Brand existBrand = null;
            if (name != null) existBrand = _brandDal.Get(brand1 => brand1.Name == name);
            else if (id != -1) existBrand = _brandDal.Get(brand1 => brand1.id == id);

            return existBrand != null ? new SuccessResult() : new ErrorResult(Messages.NotFound);
        }
    }
}