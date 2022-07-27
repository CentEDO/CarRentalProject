using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join clr in context.Colors on car.ColorId equals clr.ColorId
                             join b in context.Brands on car.Id equals b.BrandId

                             select new CarDetailDto
                             {
                                 Description=car.Description,
                                 ColorName = clr.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 BrandName = b.BrandName
                             };
                return result.ToList();
            }
        }
    }
}
