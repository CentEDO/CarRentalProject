using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Results;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarDal _carDal;
        public CarImageManager(ICarImageDal carImageDal, ICarDal carDal)
        {
            _carImageDal = carImageDal;
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var check = BusinessRules.Run(CheckImageLimit(carImage.CarId), CheckTheCarExists(carImage.CarId));
            if (check != null)
            {
                return check;
            }

            carImage.ImagePath = FormFileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(IFormFile formFile, CarImage carImage)
        {
            FormFileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(b => b.Id == imageId), Messages.CarImagesListed);
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
           
            carImage.ImagePath = FormFileHelper.Update(formFile, carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.ImageLimitofCarExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckTheCarExists(int carId)
        {
            var result = _carDal.GetAll(c => c.Id ==carId);
            if (result== null)
            {
                return new ErrorResult(Messages.CarDoesNotExist);
            }
            return new SuccessResult();
        }
    }
}
