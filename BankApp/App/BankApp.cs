using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using BankApp.Domain.Entities;
using BankApp.Domain.Enums;
using BankApp.Domain.Interfaces;
using BankApp.UI;
namespace BankApp.App
{

    public class BankApp : IUserLogin, IUserAccountActions
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void Run()
        {
            AppScreen.Welcome();
            CheckUserAccountNumberAndPassword();
            AppScreen.WelcomeCustomer(selectedAccount.FullName);
            AppScreen.DisplayAppMenu();
            ProcessMenuOption();
        }

        public void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
             new UserAccount{ UserId = 1, FullName = "Miracle Innocent", AccountNumber = 0821462072, Password = 123456, AccountBalance = 50000.00m, IsNotAUser = false},
             new UserAccount { UserId = 2, FullName = "Chistian Innocent", AccountNumber = 2066142010, Password = 543217, AccountBalance = 4000.00m, IsNotAUser = false },
             new UserAccount { UserId = 3, FullName = "Bethel Ezeh", AccountNumber = 0721072462, Password =321456, AccountBalance = 5000.00m, IsNotAUser = true },

            };

        }

        public void CheckUserAccountNumberAndPassword()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();
                foreach (UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount.AccountNumber.Equals(selectedAccount.AccountNumber))
                    {
                        selectedAccount.TotalLogin++;
                    }
                    if (inputAccount.Password.Equals(selectedAccount.Password))
                    {
                        selectedAccount = account;

                        if (selectedAccount.IsNotAUser || selectedAccount.TotalLogin > 3)
                        {
                            AppScreen.PrintBlockScreen();
                        }
                        else
                        {
                            selectedAccount.TotalLogin = 0;
                            isCorrectLogin = true;
                            break;
                        }


                    }
                }
                if (isCorrectLogin == false)
                {
                    Utility.PrintMessage("\nInvalid account number or password.", false);
                    selectedAccount.IsNotAUser = selectedAccount.TotalLogin == 3;
                    if (selectedAccount.IsNotAUser)
                    {
                        AppScreen.PrintBlockScreen();
                    }
                }
                Console.Clear();

            }



        }

        private void ProcessMenuOption()
        {
            switch (Validator.Convert<int>("an option:"))
            {
                case (int)AppMenu.CheckBalance:
                    CheckBalance();
                    break;
                case (int)AppMenu.placeDeposit:
                    Console.WriteLine("Placing deposit...");
                    break;
                case (int)AppMenu.MakeWithdrawal:
                    Console.WriteLine("Making withdrawal...");
                    break;
                case (int)AppMenu.InternalTransfer:
                    Console.WriteLine("M aking internal transfer..");
                    break;
                case (int)AppMenu.AccountStatement:
                    Console.WriteLine("Viewing account statement...");
                    break;
                case (int)AppMenu.Logout:
                    AppScreen.LogOutProgress();
                    Utility.PrintMessage("You have successfully logged out. Thank you for banking with us.");
                    Run();
                    break;
                default:
                    Utility.PrintMessage("Invalid Option.", false);
                    break;




            }

        }

        public void CheckBalance()
        {
            Utility.PrintMessage($"Your account balance is is : {Utility.FormatAmount(selectedAccount.AccountBalance)}");
            throw new NotImplementedException();
        }

        public void PlaceDeposit()
        {
            throw new NotImplementedException();
        }

        public void MakeWithdrawal()
        {
            throw new NotImplementedException();
        }
    }
}









