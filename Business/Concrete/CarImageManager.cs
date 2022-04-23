#region info

// Bilal Karataş20220329

#endregion

using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;
        private ICarService _carService;

        public CarImageManager(ICarImageDal carDal, IFileHelper fileHelper, ICarService carService)
        {
            _carImageDal = carDal;
            _fileHelper = fileHelper;
            _carService = carService;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var checkResult = CheckImageLimit(carImage.CarId);
            if (!checkResult.Success)
            {
                return new ErrorResult(checkResult.Message);
            }

            carImage.ImagePath = _fileHelper.Upload(file, ImagePathConstants.ImagePath);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageUploaded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = CarImageIsExist(carImage.Id);
            if (!result.Success) return new ErrorResult(result.Message);
            _fileHelper.Delete(ImagePathConstants.ImagePath + result.Data.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Car + " " + Messages.Deleted);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var existCarImage = CarImageIsExist(carImage.Id);
            if (!existCarImage.Success) return new ErrorResult(existCarImage.Message);
            existCarImage.Data.ImagePath = _fileHelper.Update(file,
                ImagePathConstants.ImagePath + existCarImage.Data.ImagePath,
                ImagePathConstants.ImagePath);
            _carImageDal.Update(existCarImage.Data);
            return new SuccessResult(Messages.Car + " " + Messages.ImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carService.GetById(carId);
            if (!result.Success) return new ErrorDataResult<List<CarImage>>(result.Message);
            var imageResult = _carImageDal.GetAll(carImage => carImage.CarId == carId);

            return new SuccessDataResult<List<CarImage>>(imageResult.Count == 0
                ? GetNoAvailableImage(carId).Data
                : imageResult);
        }

        private IDataResult<List<CarImage>> GetNoAvailableImage(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {new() {CarId = carId, ImagePath = "NoImageAvailable.jpg"}});
        }

        private IResult CheckImageLimit(int id)
        {
            var imagesOfCar = GetByCarId(id);

            if (imagesOfCar.Data.Count >= ConstantData.LimitOfCarImagesCount)
            {
                return new ErrorResult(Messages.NumberOfImagesExceeded + ". Max:" + ConstantData.LimitOfCarImagesCount);
            }

            return new SuccessResult(Messages.ImageAdded);
        }

        private IDataResult<CarImage> CarImageIsExist(int id)
        {
            var result = _carImageDal.Get(carImage => carImage.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.NotFound);
            }

            return new SuccessDataResult<CarImage>(result);
        }
    }
}