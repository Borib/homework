using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.Name))
            {
                Console.WriteLine("Введите имя пользователя:");
                Properties.Settings.Default.Name = Console.ReadLine();
                Console.WriteLine("Укажите ваш возраст:");
                Properties.Settings.Default.Age = Console.ReadLine();
                Console.WriteLine("Укажите ваш род деятельности:");
                Properties.Settings.Default.Work = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine($"{Properties.Settings.Default.Greeting}, {Properties.Settings.Default.Name}!");
                Console.WriteLine($"Ваш возраст: {Properties.Settings.Default.Age}!");
                Console.WriteLine($"Ваш род деятельности: {Properties.Settings.Default.Work}!");
            }

            Console.WriteLine($"Хотите очистить выаши данные перед выходом?");
            Console.WriteLine("(нажмите Y для очистки или любая другая клавиша для выхода)");
            if(Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                Properties.Settings.Default.Work = String.Empty;
                Properties.Settings.Default.Age = String.Empty;
                Properties.Settings.Default.Name = String.Empty;
                Properties.Settings.Default.Save();
            }            
        }
    }
}
