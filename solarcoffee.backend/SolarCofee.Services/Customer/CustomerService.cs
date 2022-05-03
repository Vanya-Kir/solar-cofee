using SolarCofee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarCofee.Services.Customer
{
    public class CustomerService : ICustomerService
    {

        private readonly SolarDbContext _db;

        public CustomerService(SolarDbContext db)
        {
            _db = db;
        }

        public ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Customer>
                {
                    IsSuccess = true,
                    Message = "New customer added",
                    Time = DateTime.Now,
                    Data = customer
                };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<Data.Models.Customer>
                {
                    IsSuccess = false,
                    Message = ex.StackTrace,
                    Time = DateTime.Now,
                    Data = customer
                };
            }
        }

        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);
            if(customer == null)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = "Customer deleted not find",
                    Time = DateTime.Now,
                    Data = false
                };
            }
            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = "Customer deleted",
                    Time = DateTime.Now,
                    Data = true
                };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = ex.StackTrace,
                    Time = DateTime.Now,
                    Data = false
                };
            }
        }

        public List<Data.Models.Customer> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Data.Models.Customer GetById(int id)
        {
            return _db.Customers.Find(id);
        }
    }
}
