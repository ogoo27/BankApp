using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;

namespace BankApp.UI
{
    public static class Utility
    {
        private static CultureInfo culture = new CultureInfo("IG-NG");
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string astericks = "";
           
            

            StringBuilder input = new StringBuilder();

            while (true) 
            {
                if (isPrompt)
                
                    Console.WriteLine(prompt);
                    isPrompt = false;

                    ConsoleKeyInfo inputkey = Console.ReadKey(true);
                
                if (inputkey.Key == ConsoleKey.Enter)
                {

                    if (input.Length == 6)
                    {
                        break;
                    }
                    else
                    {
                        PrintMessage("\nPlease enter 6 digits.", false);
                        input.Clear();
                        isPrompt = true;
                        continue;
                    }



                } 
                if (inputkey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
                else if (inputkey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputkey.KeyChar);
                    Console.Write(astericks + "*");
                }


            }
            return input.ToString();

        }

        public static void PrintMessage(string msg, bool success = true)
        {
            if(success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            PressEnterToContinue();
        }
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }

        public static void PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                //To delay the thread for 150 milliseconds
                Thread.Sleep(150);
            }
            //Clear the screen
            Console.Clear();

        }
        public static void PressEnterToContinue()
        {
            Console.WriteLine("\n\nPress Enter to continue...\n");
            Console.ReadLine();

        }

        public static string FormatAmount(decimal amt)
        {
            //string  format method takes in 3 parameters
            //1.gives currency symbol or info, 2. gives how
            //many decimal places you want the amt to be in
            return string.Format(culture, "{0:c2}", amt);



        }

        
    }
}
