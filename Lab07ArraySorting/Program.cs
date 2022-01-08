using System;

namespace Lab07AssignArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = ReadArray("Array");

            PrintArray("Array is ", array);

            PrintSortedArray(array);
        }

        static int ReadNumber(string label, int defaultValue)
        {
            Console.Write(label);
            string value = Console.ReadLine();
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return defaultValue;
        }

        static int[] ReadArray(string label)
        {
            int nr = ReadNumber("Array lenght: ", 0);
            int[] array = new int[nr];
            for (int i = 0; i < array.Length; i++)
            {
                int element = ReadNumber($"Element[{i}] is ", 0);
                array[i] = element;
            }

            return array;
        }

        static OrderOfSorting ReadSortingOrder(string label, OrderOfSorting defaultValue)
        {
            Console.Write(label);
            string value = Console.ReadLine();

            if(Enum.TryParse(typeof(OrderOfSorting), value, true, out object result))
            {
                return (OrderOfSorting)result;
            }

            return defaultValue;
        }

        static void PrintArray(string label, int[] array)
        {
            Console.WriteLine();
            string elementList = string.Join(", ", array);
            Console.WriteLine($"{label}= {elementList}");
        }

        public enum OrderOfSorting
        {
            Ascending,
            Descending
        }

        static void PrintSortedArray(int[] array)
        {
            OrderOfSorting sortOrder = ReadSortingOrder("Choose sorting order ascending/descending: ", OrderOfSorting.Ascending);

            int temp;
            string elementList = "";

            //ascending order
             if (sortOrder == OrderOfSorting.Ascending)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < array.Length; i++)
                {
                    elementList = string.Join(", ", array);
                }

                Console.WriteLine($"Ascending sorting: {elementList}");
            }
            //Descending order
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] < array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < array.Length; i++)
                {
                    elementList = string.Join(", ", array);
                }

                Console.WriteLine($"Descending sorting: {elementList}");
            }
        }
    }
}