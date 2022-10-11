using BankApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.App
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            
            BankApp bankApp = new BankApp();
            bankApp.InitializeData();
            bankApp.Run();
            
           
            //Utility.PressEnterToContinue();
        }
    }
}
