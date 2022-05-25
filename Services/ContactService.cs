using CRMApplication.DTO;
using CRMApplication.Entities;
using CRMApplication.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMApplication.Services
{
    public class ContactService
    {
        public static ContactService _Instance;
        public static ContactService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ContactService();
                }
                return _Instance;
            }
            private set { }
        }

        public ContactService()
        {
        }

        public async Task Create(Contact obj)
        {
            await ContactRepository.Instance.Create(obj);
        }
        public async Task Delete(Contact obj)
        {
            await ContactRepository.Instance.Delete(obj);
        }
        public async Task Update(Contact obj)
        {
            await ContactRepository.Instance.Update(obj);
        }

        public async Task<Contact> GetById(int id, int typeId)
        {
            return await ContactRepository.Instance.GetById(id, typeId);
        }
        public async Task<List<ContactDTO>> GetListContactsByCustomerId(int id)
        {
            return await ContactRepository.Instance.GetListContactsByCustomerId(id);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await ContactRepository.Instance.GetAll();
        }
    }
}
