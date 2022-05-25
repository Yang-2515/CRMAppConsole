using CRMAplication;
using CRMApplication.DTO;
using CRMApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMApplication.Repositories
{
    public class ContactRepository: BaseRepository<Contact>
    {
        public static ContactRepository _Instance;
        public static ContactRepository Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ContactRepository();
                }
                return _Instance;
            }
            private set { }
        }
        /// <summary>
        /// Lay danh sach Contact tu Customer Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns></returns>
        public async Task<List<ContactDTO>> GetListContactsByCustomerId(int id)
        {
            List<ContactDTO> contacts = new List<ContactDTO>();
            using (AppCRMContext db = new AppCRMContext())
            {
                foreach (AddressType i in await db.AddressTypes.ToListAsync())
                {
                    ContactDTO contactDTO = new ContactDTO();
                    var contact = await db.Contacts.FirstOrDefaultAsync(c => c.CustomerId == id && c.AddressTypeId == i.Id && c.Customer.IsDelete == false);
                    if (contact != null)
                    {
                        contactDTO.Email = contact.Email;
                        contactDTO.Phone = contact.Phone;
                        contactDTO.Address = contact.Address;
                        contactDTO.Type = contact.AddressType.Name;
                        contacts.Add(contactDTO);
                    }
                }
                await db.SaveChangesAsync();
            }
            return contacts;
        }
        public async Task<Contact> GetById(int id, int typeId)
        {
            using (AppCRMContext db = new AppCRMContext())
            {
                return await db.Contacts.FirstOrDefaultAsync(c => c.CustomerId == id && c.AddressTypeId == typeId && c.Customer.IsDelete == false);
            }
        }
    }
}
