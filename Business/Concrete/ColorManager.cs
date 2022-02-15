using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            var color = isColorExist(id);
            if (color == null)
            {
                return new ErrorDataResult<Color>(Messages.NotFound);
            }

            return new SuccessDataResult<Color>(color);
        }

        public IDataResult<Color> GetByName(string name)
        {
            var result = _colorDal.Get(color => color.Name == name);

            if (result == null) return new ErrorDataResult<Color>(Messages.NotFound);

            return new SuccessDataResult<Color>(result);
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteById(int id)
        {
            var result = isColorExist(id);
            if (result == null) return new ErrorResult(Messages.NotFound);

            _colorDal.Delete(result);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Color color)
        {
            var result = isColorExist(color.Id);
            if (result == null) return new ErrorResult(Messages.NotFound);

            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        private Color isColorExist(int id)
        {
            var result = _colorDal.Get(color => color.Id == id);
            return result;
        }
    }
}