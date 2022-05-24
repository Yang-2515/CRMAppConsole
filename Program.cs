using CRMApplication;
using CRMApplication.Commons;
using CRMApplication.DTO;
using CRMApplication.Entities;
using CRMApplication.Services;
using CRMApplication.UI;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMAplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool check = true;
            while (check)
            {
                //1. Show Main Menu
                UserInterface.ShowMainMenu();
                //2. User Main Menu Selection
                var selectMain = UserInterface.MenuSelection();
                //3. Show Detail Menu
                UserInterface.ShowDetailMenu(selectMain);
                //4. User Detail Menu Selection
                var selectDetail = UserInterface.MenuSelection();
                //5. Process user selection
                await UserInterface.ProcessMenuSelectionAsync(selectMain, selectDetail);
                //6. Check Continute
                UserInterface.MenuContinue();
                //7. User Selection
                check = UserInterface.CheckContinue();
            }
        }
    }
}
