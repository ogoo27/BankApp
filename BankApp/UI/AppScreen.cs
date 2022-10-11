using BankApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BankApp.UI
{
    public static class AppScreen
    {
        internal static void Welcome()
        {
            //clear the console
            Console.Clear();

            //sets the title of the console window
            Console.Title = "My Bank App";

            Console.ForegroundColor = ConsoleColor.White;

            //set the welcome message
            Console.WriteLine("\n\n---------------Hi, Welcome to Golden Bank--------------\n\n");

            //login, create an account or exit
            Console.WriteLine("Please select from these options \n 1.Login\n 2.Create an account \n 3.Exit");
           //string letter = Console.ReadLine();
           // if(letter == "1")
           // {
           //     UserLoginForm();

           // }
            

           Utility.PressEnterToContinue();

        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.AccountNumber = Validator.Convert<long>("your AccountNumber.");
            tempUserAccount.Password = Convert.ToInt32(Utility.GetSecretInput("Enter your password."));
            return tempUserAccount; 
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking account number and password...");
            Utility.PrintDotAnimation();
            
        }

        internal static void PrintBlockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is blocked. Please go to the nearest branch to unblocked your account. Thank you.", true);
            Utility.PressEnterToContinue();
            Environment.Exit(1);
        }

        internal static void WelcomeCustomer(string fullName)
        {
            Console.WriteLine($"Welcome back, {fullName}");
            Utility.PressEnterToContinue();

        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("-------My Bank App Menu--------");
            Console.WriteLine(":                             :");
            Console.WriteLine("1. Account Balance            :");
            Console.WriteLine("2. Cash Deposit               :");
            Console.WriteLine("3. Withdrawal                 :");
            Console.WriteLine("4. Transfer                   :");
            Console.WriteLine("5. Account Statement          :");
            Console.WriteLine("6. Logout                     :");

        }

        internal static void LogOutProgress()
        {
            Console.WriteLine("Thank you for using My Bank App");
            Utility.PrintDotAnimation();
            Console.Clear();

        }



    }
}
