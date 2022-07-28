using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer); ;
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Customer>>(_customerDal.GetAll(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(cu => cu.Id == customerId), Messages.UsersListed);
        }

   
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer); 
            return new SuccessResult(Messages.UserUpdated);
        }

        IDataResult<Customer> ICustomerService.GetById(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
