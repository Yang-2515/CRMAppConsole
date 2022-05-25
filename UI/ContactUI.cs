using CRMApplication.Commons;
using CRMApplication.Entities;
using CRMApplication.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMApplication.UI
{
    class ContactUI
    {
        #region Create Contact
        internal static async Task CreateContact()
        {
            //1. Choose Id Customer
            var customerContactId = UserInterface.ChooseId("customer");

            if (await CustomerService.Instance.GetById(customerContactId) != null)
            {
                //2. Choose Id Address Type
                await AddressTypeUI.ShowListAddressType();
                var addressTypeContactId = UserInterface.ChooseId("address type");

                //3. Create Contact
                if (await AddressTypeService.Instance.GetById(addressTypeContactId) != null)
                {
                    var contact = ContactInput();

                    contact.CustomerId = customerContactId;
                    contact.AddressTypeId = addressTypeContactId;
                    await ContactService.Instance.Create(contact);
                }
                else
                {
                    Console.WriteLine("Not Found!!!");
                }
            }
            else
            {
                Console.WriteLine("Not Found!!!");
            }
        }
        #endregion

        #region Delete Contact
        internal static async Task DeleteContact()
        {
            //1. Choose Id Customer
            var customerContactId = UserInterface.ChooseId("customer");

            if (await CustomerService.Instance.GetById(customerContactId) != null)
            {
                //2. Choose Id Address Type
                await AddressTypeUI.ShowListAddressType();
                var addressTypeContactId = UserInterface.ChooseId("address type");
                var contact = await ContactService.Instance.GetById(customerContactId, addressTypeContactId);

                if (contact != null)
                {
                    //3. Delete Contact
                    await ContactService.Instance.Delete(contact);
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
        #endregion

        #region Edit Contact
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
                    var contactFind = await ContactService.Instance.GetById(contact.CustomerId, contact.AddressTypeId);

                    contact.CustomerId = Convert.ToInt32(customerContactId);
                    contact.AddressTypeId = Convert.ToInt32(addressTypeContactId);
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
        #endregion

        #region Contact Input
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
        #endregion
    }
}
