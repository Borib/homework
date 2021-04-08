using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_5
{
    public static class FrequencyDictionary
    {
        public static void AnalizeFile(string sourceFile, string destFile)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            ValidateFile(sourceFile);
            ReadFile(sourceFile, result);
            result = result.OrderByDescending(s => s.Value).ToDictionary(s => s.Key, s => s.Value);
            SaveFile(destFile, result);
        }

        private static void SaveFile(string destFile, Dictionary<string, int> resultDic)
        {
            StreamWriter fileStream = null;
            try
            {
                fileStream = new StreamWriter(destFile, false, Encoding.GetEncoding(1251));
                foreach (string key in resultDic.Keys)
                {
                    fileStream.WriteLine($"{key},{resultDic[key]}");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Ошибка при записи в файл {destFile}:{Environment.NewLine}{ex.Message}");
            }
            finally
            {
                fileStream.Close();
            }            
        }

        private static void ReadFile(string sourceFile, Dictionary<string, int> dic)
        {
            StreamReader fileStream = null;
            try
            {
                fileStream = new StreamReader(sourceFile, Encoding.GetEncoding(1251));
                while (!fileStream.EndOfStream)
                {
                    string[] words = fileStream.ReadLine().Split(new string[] { Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (dic.ContainsKey(word.ToLower()))
                        {
                            dic[word.ToLower()] += 1;
                        }
                        else
                        {
                            dic.Add(word.ToLower(), 1);
                        }
                    }
                }                
            }
            catch(Exception ex)
            {
                throw new Exception($"Ошибка при чтении потока из файла {sourceFile}:{Environment.NewLine}{ex.Message}");
            }
            finally
            {
                fileStream.Close();
            }
        }

        private static bool ValidateFile(string fileName)
        {
            bool result = false;
            if (!File.Exists(fileName))
            {
                throw new Exception($"Файл {fileName} не существует");
            }          
            StreamReader fileStream = null;
            try
            {
                try
                {
                    fileStream = new StreamReader(fileName, Encoding.GetEncoding(1251));
                }
                catch(Exception ex)
                {
                    throw new Exception($"Не удалось открыть файл {fileName}.{Environment.NewLine}Ошибка: {ex.Message}");
                }
                result = true;
            }
            finally
            {
                fileStream.Close();
            }
            return result;
        }
    }
}
