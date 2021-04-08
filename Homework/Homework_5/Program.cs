using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 2 || args.Length < 2)
            {
                Console.WriteLine("Неверное количество входных параметров программы!");                
            }
            else
            {
                try
                {
                    FrequencyDictionary.AnalizeFile(args[0], args[1]);
                    Console.WriteLine($"Файл {args[0]} успешно проанализирован!{Environment.NewLine}Результат сохранён в файл {args[1]}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Нажмите любую клавишу для выхода...");
            Console.ReadKey(true);
        }
    }
}
