using System;

namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string userName = string.Empty;
                Console.WriteLine("Please enter your name:");
                userName = Console.ReadLine();                
                while (string.IsNullOrEmpty(userName))
                {
                    Console.WriteLine($"You forgot to enter your name!{Environment.NewLine}Please try again:");
                    userName = Console.ReadLine();                    
                }
                Console.WriteLine($"«Привет, {userName}, сегодня {DateTime.Now.ToShortDateString()}»");
            }
            #region errors handling
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"There is a few errors in console app:{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.InnerException.Message}");
                }
                else
                {
                    Console.WriteLine($"There is an error in console app:{Environment.NewLine}{ex.Message}");
                }
            }
            #endregion
        }
    }
}
