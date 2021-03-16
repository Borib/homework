using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = string.Empty;
            while (inputString != "exit")
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"Введите число (для выхода введите exit): ");
                    inputString = Console.ReadLine();
                    while (String.IsNullOrEmpty(inputString))
                    {
                        Console.Clear();
                        Console.WriteLine($"Вы не ввели число! Ещё попытка (либо введите exit):");
                        inputString = Console.ReadLine();                        
                    }
                    string resultString = "";
                    //первый способ преобразования
                    if (inputString != "exit" && inputString.All(Char.IsDigit))
                    {
                        for (int i = inputString.Length - 1; i >= 0; i--)
                        {
                            resultString += inputString[i];
                        }
                        Console.WriteLine($"Преобразование первым способом: {Convert.ToInt32(resultString)}");
                        //второй способ преобразования
                        List<char> TMPChars = inputString.ToList();
                        TMPChars.Reverse();
                        resultString = String.Join(string.Empty, TMPChars.ToArray());
                        Console.WriteLine($"Преобразование вторым способом: {Convert.ToInt32(resultString)}");
                        //третий способ преобразования
                        int TMPDigit = 0;
                        int Digit = 0;
                        while (inputString.Length > 0)
                        {
                            TMPDigit += Convert.ToInt32(inputString) % 10;
                            inputString = ((int)(Convert.ToInt32(inputString) / 10)).ToString();
                            inputString = inputString.Remove(inputString.Length - 1);
                            Digit *= 10;
                            Digit += TMPDigit;
                        }
                        Console.WriteLine($"Преобразование третьим способом: {Convert.ToInt32(resultString)}");

                        Console.WriteLine($"{Environment.NewLine}(нажмите любую клавишу для продолжения)");
                        Console.ReadKey();
                    }
                    else
                    {
                        if(inputString.All(Char.IsDigit) == false)
                        {
                            Console.WriteLine($"Введённая строка не является числом. Попробуйте ещё раз!");
                            Console.WriteLine($"{Environment.NewLine}(нажмите любую клавишу для продолжения)");
                            Console.ReadKey();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException == null ? ex.Message : $"{ex.Message}{Environment.NewLine}{ex.InnerException.Message}");
                    Console.ReadKey();
                }
            }            
        }
    }
}
