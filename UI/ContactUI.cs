using CRMApplication.Commons;
using CRMApplication.Entities;
using CRMApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMApplication.UI
{
    class ContactUI
    {
        internal static async Task<List<Contact>> ContactsInput(int id)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (AddressType item in await AddressTypeService.Instance.GetAll())
            {
                Console.WriteLine("Address " + item.Name + ":");
                Contact contact = new Contact();
                Console.WriteLine("Address: ");
                contact.Address = Console.ReadLine();
                Console.WriteLine("Email: ");
                contact.Email = Console.ReadLine();
                Console.WriteLine("Phone ");
                contact.Phone = Console.ReadLine();
                while (!Helper.IsNumber(contact.Phone))
                {
                    Console.WriteLine("Phone must be a number!!!");
                    Console.WriteLine("Write Phone again:");
                    contact.Phone = Console.ReadLine();
                }
                contact.CustomerId = id;
                contact.AddressTypeId = item.Id;
                contacts.Add(contact);
            }
            return contacts;
        }

        internal static async Task DeleteContact()
        {
            //1. Choose Id Customer
            var customerContactId = UserInterface.ChooseId("customer");
            if (await CustomerService.Instance.GetById(customerContactId) != null)
            {
                //2. Choose Id Address Type
                await AddressTypeUI.ShowListAddressType();
                var addressTypeContactId = UserInterface.ChooseId("address type");
                if (await ContactService.Instance.GetById(customerContactId, addressTypeContactId) != null)
                {
                    await ContactService.Instance.Delete(await ContactService.Instance.GetById(Convert.ToInt32(customerContactId), Convert.ToInt32(addressTypeContactId)));
                }
                else
                {
                    Console.WriteLine("Not found!!!");
                }
            }
            else
            {
                Console.WriteLine("Not Found!!!");
            }
        }

        internal static async Task EditContact()
        {
            //1. Choose Id Customer
            var customerContactId = UserInterface.ChooseId("customer");
            if (await CustomerService.Instance.GetById(customerContactId) != null)
            {
                //2. Choose Id Address Type
                await AddressTypeUI.ShowListAddressType();
                var addressTypeContactId = UserInterface.ChooseId("address type");
                if(await ContactService.Instance.GetById(customerContactId, addressTypeContactId) != null)
                {
                    //3. Write Infomation Update
                    var contact = ContactInput();
                    contact.CustomerId = Convert.ToInt32(customerContactId);
                    contact.AddressTypeId = Convert.ToInt32(addressTypeContactId);
                    var contactFind = await ContactService.Instance.GetById(contact.CustomerId, contact.AddressTypeId);
                    contact.Id = contactFind.Id;
                    //4. Update Customer
                    await ContactService.Instance.Update(contact);
                }
                else
                {
                    Console.WriteLine("Not found!!!");
                }
            }
            else
            {
                Console.WriteLine("Not Found!!!");
            }
            
        }

        private static Contact ContactInput()
        {
            Contact contact = new Contact();
            Console.WriteLine("Address: ");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Email: ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Phone ");
            contact.Phone = Console.ReadLine();
            while (!Helper.IsNumber(contact.Phone))
            {
                Console.WriteLine("Phone must be a number!!!");
                Console.WriteLine("Write Phone again:");
                contact.Phone = Console.ReadLine();
            }
            return contact;
        }
    }
}
