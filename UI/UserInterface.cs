using CRMApplication.Commons;
using System;
using System.Threading.Tasks;

namespace CRMApplication.UI
{
    public class UserInterface
    {
        public static async Task ProcessMenuSelectionAsync(string selectMain, string selectDetail)
        {
            switch (selectMain)
            {
                case "1":
                    switch (selectDetail)
                    {
                        case "1":
                            //Show All Customer
                            CustomerUI.ShowAllCustomer();
                            break;
                        case "2":
                            //Show Detail Customer
                            await CustomerUI.ShowCustomerById();
                            break;
                    }
                    break;

                case "2":
                    switch (selectDetail)
                    {
                        case "1":
                            //Create Customer
                            await CustomerUI.CreateCustomer();
                            break;
                        case "2":
                            //Create AddressType
                            await AddressTypeUI.CreateAddressType();
                            break;
                        case "3":
                            //Create Contact
                            await ContactUI.CreateContact();
                            break;
                    }
                    break;

                case "3":
                    switch (selectDetail)
                    {
                        case "1":
                            //Delete Customer
                            await CustomerUI.DeleteCustomer();
                            break;
                        case "2":
                            //Delete AddressType
                            await AddressTypeUI.DeleteAddressType();
                            break;
                        case "3":
                            //Delete Contact
                            await ContactUI.DeleteContact();
                            break;
                    }
                    break;

                case "4":
                    switch (selectDetail)
                    {
                        case "1":
                            //Edit Customer
                            await CustomerUI.EditCustomer();
                            break;
                        case "2":
                            //Edit AddressType
                            await AddressTypeUI.EditAddressType();
                            break;
                        case "3":
                            //Edit Contact
                            await ContactUI.EditContact();
                            break;
                    }
                    break;
            }
        }
        internal static int CheckNumber(string id)
        {
            while (!Helper.IsNumber(id))
            {
                Console.WriteLine("Must be a number!!!");
                Console.WriteLine("Write again:");
                id = Console.ReadLine();
            }
            return Convert.ToInt32(id);
        }

        public static bool CheckContinue()
        {
            int select = Convert.ToInt32(Console.ReadLine());

            if(select == 1)
            {
                return true;
            }
            return false;
        }

        public static void MenuContinue()
        {
            Console.WriteLine("\n?????????????????????????");
            Console.WriteLine("Do you continue?");
            Console.WriteLine("1. Yes \n2. No");
        }

        internal static int ChooseId(string name)
        {
            Console.Write("Write " + name + " Id: ");
            var res = Console.ReadLine();
            return CheckNumber(res);
        }

        public static string MenuSelection()
        {
            Console.Write("Your choose: ");
            return Console.ReadLine();
        }

        public static void ShowDetailMenu(string selectMain)
        {
            switch (selectMain)
            {
                case "1":
                    Console.WriteLine("======================================");
                    Console.WriteLine("1. View List Customer \n2. View Detail Customer");
                    break;

                case "2":
                    Console.WriteLine("======================================");
                    Console.WriteLine("1. Create Customer \n2. Create Address Type \n3. Create Contact For Customer");
                    break;

                case "3":
                    Console.WriteLine("======================================");
                    Console.WriteLine("1. Delete Customer \n2. Delete Address Type \n3. Delete Contact");
                    break;

                case "4":
                    Console.WriteLine("======================================");
                    Console.WriteLine("1. Edit Customer \n2. Edit Address Type \n3. Edit Contact For Customer");
                    break;
            }
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("---------------CRM App----------------");
            Console.WriteLine("Menu:");
            //Xay dung 2 luong chuc nang cho Customer, Address Type
            Console.WriteLine("1. View \n2. Create \n3. Delete \n4. Edit");
        }
    }
}
