using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Specialized;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger UserInput, ResultFactorial;
            
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"Введите целое положительное число, для которого требуется вычислить факториал (введите \"exit\" для выхода):");
                    string EnteredString = Console.ReadLine();
                    if (EnteredString.ToLower() == "exit") return;
                    UserInput = Convert.ToUInt32(EnteredString);
                    if (UserInput < 0)  //проверка на отрицательные числа
                    {
                        throw new Exception();
                    }
                    else
                    {
                        string outputString;
                        ResultFactorial = GetFactorialIterative(UserInput);
                        if (ResultFactorial.ToString().Length > 50)  //если результат более 50 знаков, то выводим в экспоненциальной форме
                        {
                            outputString = ResultFactorial.ToString("E");
                        }
                        else
                        {
                            outputString = ResultFactorial.ToString();
                        }
                        Console.WriteLine($"Факториал числа {UserInput} равен {outputString}.{Environment.NewLine}Нажмите любую клавишу для повторного ввода...");
                    }
                }
                catch
                {                    
                    Console.WriteLine("Введено некорректное число, попробуйте снова. Нажмите любую клавишу для повторного ввода...");
                }
                Console.ReadKey(true);
            }
        }

        //нерекурсивный метод вычисления факториала
        static BigInteger GetFactorialIterative(BigInteger num)
        {
            BigInteger factorial = 1;
            while (num > 1)
            {
                factorial *= num--;
            }
            return factorial;
        }
    }
}
