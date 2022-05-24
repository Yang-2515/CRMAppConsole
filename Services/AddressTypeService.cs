using CRMApplication.Entities;
using CRMApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMApplication.Services
{
    public class AddressTypeService
    {
        public static AddressTypeService _Instance;
        public static AddressTypeService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AddressTypeService();
                }
                return _Instance;
            }
            private set { }
        }
        public AddressTypeService()
        {
        }

        public async Task Create(AddressType obj)
        {
            await AddressTypeRepository.Instance.Create(obj);
        }
        public async Task Delete(AddressType obj)
        {
            await AddressTypeRepository.Instance.Delete(obj);
        }
        public async Task Update(AddressType obj)
        {
            await AddressTypeRepository.Instance.Update(obj);
        }

        public async Task<AddressType> GetById(int id)
        {
            return await AddressTypeRepository.Instance.GetById(id);
        }

        public async Task<IEnumerable<AddressType>> GetAll()
        {
            return await AddressTypeRepository.Instance.GetAll();
        }
    }
}
