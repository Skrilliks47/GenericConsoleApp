using System;
using System.Collections.Generic;

namespace GenericConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторная работа ===\n");

            // ПУНКТ 4: Проверка GenericClass для float и bool
            Console.WriteLine("--- 1. GenericClass<T> ---");
            
            var floatContainer = new GenericClass<float>();
            floatContainer.SetValue(3.14159f);
            Console.WriteLine($"Float: {floatContainer.GetValue()}");
            
            var boolContainer = new GenericClass<bool>();
            boolContainer.SetValue(true);
            Console.WriteLine($"Bool: {boolContainer.GetValue()}");
            
            Console.WriteLine();

            // ПУНКТ 6: Проверка статических методов
            Console.WriteLine("--- 2. StaticMethodsClass ---");
            
            int a = 10, b = 20;
            Console.WriteLine($"До Swap: a={a}, b={b}");
            StaticMethodsClass.Swap(ref a, ref b);
            Console.WriteLine($"После Swap: a={a}, b={b}");
            
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.Write("PrintCollection: ");
            StaticMethodsClass.PrintCollection(numbers);
            Console.WriteLine();

            // ПУНКТ 8: Проверка Min/Max
            Console.WriteLine("--- 3. MinMaxClass ---");
            Console.WriteLine($"Max(5, 10) = {MinMaxClass.Max(5, 10)}");
            Console.WriteLine($"Min(5, 10) = {MinMaxClass.Min(5, 10)}");
            Console.WriteLine($"Max(3.5, 2.8) = {MinMaxClass.Max(3.5, 2.8)}");
            Console.WriteLine($"Min('b', 'a') = {MinMaxClass.Min('b', 'a')}");
            Console.WriteLine();

            // ПУНКТ 12: Проверка OperationResult
            Console.WriteLine("--- 4. OperationResult<T> ---");
            
            // Успешное создание
            var result = CreatePerson("Иван", 25);
            PrintResult(result);
            
            // Ошибка
            var result2 = CreatePerson("", 30);
            PrintResult(result2);
        }

        static OperationResult<Person> CreatePerson(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult<Person>.Failure("Ошибка: Имя не может быть пустым");
            
            if (age < 0 || age > 150)
                return OperationResult<Person>.Failure($"Ошибка: Некорректный возраст {age}");
            
            return OperationResult<Person>.Success(new Person(name, age));
        }

        static void PrintResult<T>(OperationResult<T> result)
        {
            if (result.IsSuccess && result.Value != null)
                Console.WriteLine($"✓ УСПЕХ: {result.Value}");
            else
                Console.WriteLine($"✗ ОШИБКА: {result.ErrorMessage}");
        }
    }
}