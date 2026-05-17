using System.Collections.Generic;

namespace GenericConsoleApp
{
    public static class StaticMethodsClass
    {
        // Обмен значениями
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // Вывод коллекции
        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            System.Console.WriteLine(string.Join(", ", collection));
        }
    }
}