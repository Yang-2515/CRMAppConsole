using CRMApplication.Entities;
using CRMApplication.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApplication.Services
{
    public class CustomerService
    {
        public static CustomerService _Instance;
        public static CustomerService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerService();
                }
                return _Instance;
            }
            private set { }
        }

        public CustomerService()
        {
        }

        public async Task Create(Customer obj)
        {
            await CustomerRepository.Instance.Create(obj);
        }
        public async Task Delete(Customer obj)
        {
            obj.IsDelete = true;
            await Update(obj);
        }
        public async Task Update(Customer obj)
        {
            await CustomerRepository.Instance.Update(obj);
        }

        public async Task<Customer> GetById(int id)
        {
            return await CustomerRepository.Instance.GetById(id);
        }

        public List<Customer> GetAll()
        {
            return CustomerRepository.Instance.GetAll().Result.Where(c => c.IsDelete == false).ToList();
        }
    }
}
