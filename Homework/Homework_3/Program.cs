using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stopwatch SW = new Stopwatch();
                string[] NumbersInString;  //исходный массив строк, введённый пользователем
                int[] Numbers;  //исходный массив чисел, преобразованный из строк NumbersInString
                while (true)
                {
                    Console.Clear();
                    Numbers = new int[0];
                    Console.WriteLine("Введите 10 чисел через пробел (для выхода введите \"exit\"):");
                    NumbersInString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (NumbersInString.Length > 10)
                    {
                        Console.WriteLine($"Вы ввели больше 10 чисел!{Environment.NewLine}Нажмите любую клавишу для повторной попытки...");                        
                    }
                    else if (NumbersInString.Length < 10)
                    {
                        if (NumbersInString[0].ToLower().Trim() == "exit")  //обработка команды выхода из программы
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine($"Вы ввели меньше 10 чисел!{Environment.NewLine}Нажмите любую клавишу для повторной попытки...");
                        }
                    }
                    else
                    {
                        try
                        {
                            foreach(string numStr in NumbersInString)
                            {
                                Array.Resize(ref Numbers, Numbers.Length + 1);
                                Numbers[Numbers.Length - 1] = int.Parse(numStr);
                            }
                            break;  //все проверки прошли успешно, переход к сортировке и выводу результатов
                        }
                        catch
                        {                            
                            Console.WriteLine($"Не все введённые значения были корректными числами!{Environment.NewLine}Нажмите любую клавишу для повторной попытки...");
                        }
                    }
                    Console.ReadKey(true);  //ожидание ввода пользователя после каждого из сообщений
                }
                Console.Clear();
                int[] result;  //массив для вывода результатов
                Console.WriteLine($"Исходный массив: {String.Join(" ", Numbers.Select(s => s.ToString()))}");
                #region BubbleSort
                SW.Start();
                result = BubbleSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка пузырьком: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region StoogeSort
                SW.Restart();
                result = StoogeSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка по частям: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region ShakerSort
                SW.Restart();
                result = ShakerSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка перемешиванием: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region InsertionSort
                SW.Restart();
                result = InsertionSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка вставками: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region QuickSort
                SW.Restart();
                result = QuickSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка Хоара (быстрая): {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region SelectionSort
                SW.Restart();
                result = SelectionSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка выбором: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region PancakeSort
                SW.Restart();
                result = PancakeSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Блинная сортировка: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region MergeSort
                SW.Restart();
                result = MergeSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка слиянием: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                #region ShellSort
                SW.Restart();
                result = ShellSort(Numbers);
                SW.Stop();
                Console.WriteLine($"Сортировка Шелла: {String.Join(" ", result.Select(s => s.ToString()))}");
                Console.WriteLine($"Затрачено времени: {SW.Elapsed.ToString()}");
                #endregion
                Console.ReadKey(true);  //ожидание ввода пользователя
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException != null ? $"{ex.Message}{Environment.NewLine}{ex.InnerException.Message}" : ex.Message);
                Console.ReadKey(true);
            }
        }

        #region Методы сортировки
        #region Сортировка Шелла
        public static int[] ShellSort(int[] array)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }
        #endregion
        #region Сортировка слиянием
        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }
            return array;
        }

        public static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
        #endregion
        #region Блинная сортировка
        public static int[] PancakeSort(int[] array)
        {
            for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
            {
                //получаем позицию максимального элемента подмассива
                var indexOfMax = IndexOfMax(array, subArrayLength);
                if (indexOfMax != subArrayLength)
                {
                    //переворот массива до индекса максимального элемента
                    //максимальный элемент подмассива расположится вначале
                    Flip(array, indexOfMax);
                    //переворот всего подмассива
                    Flip(array, subArrayLength);
                }
            }
            return array;
        }
        #endregion
        #region Сортировка выбором
        public static int[] SelectionSort(int[] array, int currentIndex = 0)
        {
            if (currentIndex == array.Length)
                return array;

            var index = IndexOfMin(array, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref array[index], ref array[currentIndex]);
            }

            return SelectionSort(array, currentIndex + 1);
        }
        #endregion
        #region Сортировка Хоара (быстрая сортировка)      
        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        #endregion
        #region Сортировка вставками
        public static int[] InsertionSort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 0) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }
            return array;
        }
        #endregion
        #region Шейкерная сортировка (сортировка перемешиванием)
        public static int[] ShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
        #endregion
        #region Сортировка пузырьком (пузырьковая сортировка)
        public static int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }
        #endregion
        #region Сортировка по частям
        private static int[] StoogeSort(int[] array, int startIndex, int endIndex)
        {
            if (array[startIndex] > array[endIndex])
            {
                Swap(ref array[startIndex], ref array[endIndex]);
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                StoogeSort(array, startIndex, endIndex - len);
                StoogeSort(array, startIndex + len, endIndex);
                StoogeSort(array, startIndex, endIndex - len);
            }

            return array;
        }

        public static int[] StoogeSort(int[] array)
        {
            return StoogeSort(array, 0, array.Length - 1);
        }
        #endregion
        #endregion
        #region вспомогательные методы для сортировок
        //метод для обмена элементов
        private static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
        //метод для слияния массивов
        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        //метод для переворота массива
        private static void Flip(int[] array, int end)
        {
            for (var start = 0; start < end; start++, end--)
            {
                var temp = array[start];
                array[start] = array[end];
                array[end] = temp;
            }
        }
        //метод поиска позиции минимального элемента подмассива, начиная с позиции n
        private static int IndexOfMin(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }
            return result;
        }
        //метод для получения индекса максимального элемента подмассива
        private static int IndexOfMax(int[] array, int n)
        {
            int result = 0;
            for (var i = 1; i <= n; ++i)
            {
                if (array[i] > array[result])
                {
                    result = i;
                }
            }
            return result;
        }
        //метод возвращающий индекс опорного элемента
        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        #endregion
    }
}
