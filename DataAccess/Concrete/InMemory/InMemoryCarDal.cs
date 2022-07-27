using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=300,ModelYear="2016",Description="2016 Volkswagen Passat"},
                new Car{Id=2,BrandId=1,ColorId=3,DailyPrice=250,ModelYear="2018",Description="2018 Mini Cooper"},
                new Car{Id=3,BrandId=2,ColorId=5,DailyPrice=500,ModelYear="2020",Description="2020 Peugeot 3008"},
                new Car{Id=4,BrandId=1002,ColorId=4,DailyPrice=300,ModelYear="2021",Description="2021 Hyundai Kona"},
                new Car{Id=5,BrandId=9,ColorId=4,DailyPrice=250,ModelYear="2019",Description="2019 Nissan Qashqai"},
                new Car{Id=6,BrandId=12,ColorId=2,DailyPrice=150,ModelYear="2018",Description="2018 Kia Sportage"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
