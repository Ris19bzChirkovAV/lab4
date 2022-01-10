using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int change;
            string buf;
            int count = 0;
            int count2 = 0;
            int num;
            int number;
            Random rand = new Random();
            Console.WriteLine("Введите количество элементов:");
            buf = Console.ReadLine();
            change = int.Parse(buf);
            int [] arr = new int[change];
            for (int i = 0; i < change; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                    count++;
                if (arr[i] >= 0)
                    count2++;
                Console.Write($"{arr[i]} ");
            }
            Console.ReadLine();
            int[] arr2 = new int[count];
            int[] arr3 = new int[count2];
            Console.WriteLine("\n");
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Удаление всех нечетных элементов");
                Console.WriteLine("2 - Добавление N элементов с номера К");
                Console.WriteLine("3 - Перестановка положительных элементов в начало массива, отрицательные в конец");
                Console.WriteLine("4 - Поиск по заданному ключу/значению");
                Console.WriteLine("5 - Сортировка массива простым обменом");
                Console.WriteLine("6 - Показать данные массива");
                Console.WriteLine("0 - Выход");
                buf = Console.ReadLine();
                number = int.Parse(buf);
                switch (number)
                {
                    case 1:
                        count = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i] % 2 == 0)
                            {
                                arr2[count] = arr[i];
                                count++;
                            }
                        }
                        Array.Resize(ref arr, count);
                        count = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = arr2[i];
                            if (arr[i] >= 0)
                                count++;
                            Console.Write($"{arr[i]} ");
                        }
                        Array.Resize(ref arr3, count);
                        Console.ReadLine();
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.WriteLine("Введите количество элементов:");
                        buf = Console.ReadLine();
                        change = int.Parse(buf);
                        Console.WriteLine("Введите номер элемента с которого начинается добавление:");
                        buf = Console.ReadLine();
                        num = int.Parse(buf);
                        Array.Resize(ref arr2, arr2.Length + change);
                        for (int i = 0; i < arr2.Length; i++)
                        {
                            if (i <= num)
                                arr2[i] = arr[i];
                            if (i > num && i <= num + change)
                                arr2[i] = rand.Next(-100, 100);
                            if (i > num + change)
                                arr2[i] = arr[i - change];
                        }
                        Array.Resize(ref arr, arr2.Length);
                        count = 0;
                        for (int i = 0; i < arr2.Length; i++)
                        {
                            arr[i] = arr2[i];
                            if (arr[i] >= 0)
                                count++;
                            Console.Write($"{arr[i]} ");
                        }
                        Array.Resize(ref arr3, count);
                        Console.ReadLine();
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        count = 0;
                        count2 = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i] >= 0)
                            {
                                arr3[count] = arr[i];
                                count++;
                            }
                            else
                            {
                                arr2[count2] = arr[i];
                                count2++;
                            }
                        }
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i < arr3.Length)
                                arr[i] = arr3[i];
                            else
                                arr[i] = arr2[i - arr3.Length];
                            Console.Write($"{arr[i]} ");
                        }
                        Console.ReadLine();
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.WriteLine("Поиск по ключу - 1, по значению - 2");
                        buf = Console.ReadLine();
                        change = int.Parse(buf);
                        count = 0;
                        if (change == 1)
                        {
                            Console.WriteLine("Введите ключ:");
                            buf = Console.ReadLine();
                            num = int.Parse(buf);
                            if (num < 0 || num > arr.Length)
                            {
                                Console.WriteLine("Вы ввели неверные данные");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"{arr[num]} - Количество сравнений: {count}");
                                Console.ReadLine();
                            }
                        }
                        else if (change == 2)
                        {
                            Console.WriteLine("Введите значение:");
                            buf = Console.ReadLine();
                            num = int.Parse(buf);
                            for (int i = 0; i < arr.Length; i++)
                            {
                                
                                if (arr[i] == num)
                                    break;
                                count++;

                            }
                            if (count == arr.Length)
                                Console.WriteLine("Элемент не найден");
                            else
                                Console.WriteLine($"{arr[count]} - Количество сравнений: {count + 1}");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели неверные данные");
                            Console.ReadLine();
                        }
                        
                        break;
                    case 5:
                        Array.Resize(ref arr2, arr.Length);
                        int rec = -2147483648;
                        for (int i = 0; i < arr.Length; i++)
                            arr2[i] = arr[i];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for (int j = 0; j < arr2.Length; j++)
                            {
                                if (rec < arr2[j] && arr2[j] != 0)
                                {
                                    rec = arr2[j];
                                    count = j;
                                }

                            }
                            arr2[count] = 0;
                            arr[i] = rec;
                            rec = -2147483648;
                        }
                        for (int i = 0; i < arr.Length; i++)
                            Console.Write($"{arr[i]} ");
                        Console.ReadLine();
                        break;
                    case 6:
                        for (int i = 0; i < arr.Length; i++)
                            Console.Write($"{arr[i]} ");
                        Console.ReadLine();
                        break;

                }

            } while (number != 0);
        }
    }
}
