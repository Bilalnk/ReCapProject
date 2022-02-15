using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
        IDataResult<Color> GetByName(string name);
        IResult Add(Color color);
        IResult DeleteById(int id);
        IResult Update(Color color);
    }
}