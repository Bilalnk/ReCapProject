#region info

// Bilal Karataş20220329

#endregion

using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
    }
}