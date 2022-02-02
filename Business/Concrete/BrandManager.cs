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

        public IDataResult<Brand> GetById(int categoryId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.id == categoryId));
        }

        public IDataResult<Brand> GetByName(string name)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.Name.Equals(name)));
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Equals(null) || brand.Name.Equals("") || brand.Name.Equals(" "))
            {
                return new ErrorResult(Constants.Messages.BrandNameNotNull);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult DeleteById(int id)
        {
            Brand brand = _brandDal.Get(brand1 => brand1.id == id);
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated + " " + brand.id + " " + brand.Name);
        }

        public IDataResult<Brand> Get(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.id == id));
        }
    }
}