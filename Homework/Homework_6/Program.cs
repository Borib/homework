using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Homework_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Console.WriteLine("Программа Task Manager"); 
            Console.WriteLine("(для вывода списка команд введите help)");
            while (true)
            {                
                Console.WriteLine("Введите команду:");
                command = Console.ReadLine();
                if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower() == "list")
                {
                    List(command);
                }
                else if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower() == "killbyid")
                {
                    KillByID(command);
                }
                else if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower() == "killbyname")
                {
                    KillByName(command);
                }
                else if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower() == "help")
                {
                    Console.Clear();
                    Console.WriteLine("Команды доступные для использования:");
                    Console.WriteLine("help - справка о доступных командах");
                    Console.WriteLine("list - вывести список всех процессов");
                    Console.WriteLine("list <имя процесса> - вывести список процессов с указанным именем");
                    Console.WriteLine("killbyid <ID процесса> - завершить процесс по идентификатору. Пример: killbyid 22704");
                    Console.WriteLine("killbyname <имя процесса> - завершить процессы с указанным именем. Пример: killbyid notepad.exe");
                    Console.WriteLine("exit - выход из программы");
                }
                else if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Команда не распознана. Для вывода списка команд введите help.");
                }
            }
        }

        private static string SetSpaces(int count)
        {
            string result = string.Empty;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    result += " ";
                }
            }
            return result;
        }

        private static void List(string command)
        {
            Console.Clear();
            Process[] procs = null;
            if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 1)
            {
                procs = Process.GetProcesses();
            }
            else if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
            {
                procs = Process.GetProcessesByName(command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            else
            {
                Console.WriteLine($"Неверное количество параметров команды list.");
                return;
            }
            if (procs.Length == 0)
            {
                Console.WriteLine($"Процессы с указанным именем не найдены.");
            }
            else
            {
                Console.WriteLine($"Имя процесса{SetSpaces(50 - 12)}ID процесса");
                foreach (Process pr in procs)
                {
                    Console.WriteLine($"{pr.ProcessName}{SetSpaces(50 - pr.ProcessName.Length)}{pr.Id}");
                }
            }
        }

        private static void KillByName(string command)
        {
            Console.Clear();
            Process[] procs = null;
            if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
            {
                procs = Process.GetProcessesByName(command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            else
            {
                Console.WriteLine($"Неверное количество параметров команды killbyname.");
                return;
            }
            if (procs.Length == 0)
            {
                Console.WriteLine($"Процессы с указанным именем не найдены.");
            }
            else
            {
                string name = string.Empty;
                string id = string.Empty;
                foreach (Process pr in procs)
                {
                    name = pr.ProcessName;
                    id = pr.Id.ToString();
                    try
                    {
                        pr.Kill();
                        Console.WriteLine($"Процесс {name} с id {id} завершён.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Процесс {name} с id {id} не удалось завершить.{Environment.NewLine}Причина: {ex.Message}");
                    }                    
                }
            }
        }

        private static void KillByID(string command)
        {
            Console.Clear();
            Process proc = null;
            if (command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
            {
                try
                {
                    proc = Process.GetProcessById(Convert.ToInt32(command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]));
                }
                catch
                {
                    Console.WriteLine($"Указан некорректный ID процесса.");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Неверное количество параметров команды killbyid.");
                return;
            }
            if (proc == null)
            {
                Console.WriteLine($"Процесс с указанным ID не найден.");
                return;
            }
            else
            {
                string name = proc.ProcessName;
                string id = proc.Id.ToString();
                try
                {
                    proc.Kill();
                    Console.WriteLine($"Процесс {name} с id {id} завершён.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Процесс {name} с id {id} не удалось завершить.{Environment.NewLine}Причина: {ex.Message}");
                }
            }
        }

    }
}
