using CRMApplication.Entities;
using CRMApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMApplication.UI
{
    class AddressTypeUI
    {
        internal static async Task CreateAddressType()
        {
            //1. Input Address Type
            var addressType = AddressTypeInput();
            //2. Create AddressType
            await AddressTypeService.Instance.Create(addressType);
        }

        internal static async Task DeleteAddressType()
        {
            //1. Show List Address Type 
            await ShowListAddressType();
            //2. Choose Id
            var addressTypeId = UserInterface.ChooseId("addressType");
            //3. Delete AddressType
            if( await AddressTypeService.Instance.GetById(addressTypeId) != null)
            {
                await AddressTypeService.Instance.Delete(await AddressTypeService.Instance.GetById(addressTypeId));
            }
            else
            {
                Console.WriteLine("Not Found!!!");
            }
        }

        internal static async Task EditAddressType()
        {
            //1. Show List Address Type 
            await ShowListAddressType();
            //2. Choose Id AddressType
            var addressTypeId = UserInterface.ChooseId("address type");
            //3. Write Infomation Update
            var addressType = AddressTypeInput();
            addressType.Id = addressTypeId;
            //4. Update Address Type
            if(await AddressTypeService.Instance.GetById(addressTypeId) != null)
            {
                await AddressTypeService.Instance.Update(addressType);
            }
            else
            {
                Console.WriteLine("Not found!!!");
            }
        }

        internal static async Task ShowListAddressType()
        {
            foreach (AddressType item in await AddressTypeService.Instance.GetAll())
            {
                Console.WriteLine(item.Id + ". Address " + item.Name);
            }
        }

        private static AddressType AddressTypeInput()
        {
            AddressType type = new AddressType();
            Console.WriteLine("Write address type information");
            Console.WriteLine("Name: ");
            type.Name = Console.ReadLine();
            return type;
        }
    }
}
