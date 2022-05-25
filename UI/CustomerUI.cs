using CRMApplication.DTO;
using CRMApplication.Entities;
using CRMApplication.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMApplication.UI
{
    class CustomerUI
    {
        #region View Customer
        internal static void ShowAllCustomer()
        {
            //1. Get All Customer
            var customers = CustomerService.Instance.GetAll();

            //2. Show
            foreach (Customer c in customers)
            {
                c.Show();
            }
        }

        internal static async Task ShowCustomerById()
        {
            //1. Choose Id
            var id = UserInterface.ChooseId("customer");

            //2. Get Customer Detail
            var customer = await CustomerService.Instance.GetById(id);

            if (customer != null)
            {
                //3. Get contact for Customer
                var contacts = await ContactService.Instance.GetListContactsByCustomerId(id);

                //4. Show Customer Detail
                ShowCustomerDetail(customer, contacts);
            }
            else
            {
                Console.WriteLine("Not found!!!");
            }
        }

        private static void ShowCustomerDetail(Customer customer, List<ContactDTO> contacts)
        {
            //1. Show Customer
            customer.Show();

            //2. Show Contacts For Customer
            foreach (ContactDTO i in contacts)
            {
                i.Show();
            }
        }
        #endregion

        #region Create Customer
        internal static async Task CreateCustomer()
        {
            //1. Input Customer
            var customer = CustomerInput();

            customer.CreatedAt = DateTime.Now;

            //2. Create Customer
            await CustomerService.Instance.Create(customer);

            //3. Input Customer
            var contacts = ContactUI.ContactsInput(customer.Id);

            //4. Create Contact For Customer
            foreach (Contact item in contacts.Result)
            {
                await ContactService.Instance.Create(item);
            }
            Console.WriteLine("Successfuly!!!");
        }
        #endregion

        #region Delete Customer
        internal static async Task DeleteCustomer()
        {
            //1. Choose Id
            var customerId = UserInterface.ChooseId("customer");

            //2. Delete Customer
            var customer = await CustomerService.Instance.GetById(customerId);

            if(customer != null)
            {
                await CustomerService.Instance.Delete(customer);
                Console.WriteLine("Successfuly!!!");
            }
            else
            {
                Console.WriteLine("Not found!!!");
            }
        }
        #endregion

        #region Edit Customer
        internal static async Task EditCustomer()
        {
            //1. Choose Id Customer
            var customerId = UserInterface.ChooseId("customer");
            
            if( await CustomerService.Instance.GetById(customerId) != null)
            {
                //2. Write Infomation Update
                var customer = CustomerInput();

                customer.UpdatedAt = DateTime.Now;
                customer.Id = Convert.ToInt32(customerId);

                //3. Update Customer
                await CustomerService.Instance.Update(customer);
            }
            else
            {
                Console.WriteLine("Not found!!!");
            }
        }
        #endregion

        #region Customer Input
        private static Customer CustomerInput()
        {
            Console.WriteLine("======================================");
            Customer customer = new Customer();
            Console.WriteLine("Write Customer Infomation:");
            Console.WriteLine("Name:");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Gender: \n 1.Nam \n 2.Nu \n 3.None");
            var gender = UserInterface.ChooseId("gender");
            if (gender == 1) customer.Gender = "Nam";
            if (gender == 2) customer.Gender = "Nu";
            if (gender == 3) customer.Gender = "None";
            var i = UserInterface.ChooseId("age");
            customer.Age = i;
            customer.IsDelete = false;
            return customer;
        }
        #endregion
    }
}
