﻿using System;
class Program                                //Для демонстрації роботи
{
    static void Main(string[] args)
    {
        Calculator<int> intCalculator = new Calculator<int>();
        Console.WriteLine("Addition: " + intCalculator.PerformOperation(5, 3, intCalculator.Add));
        Console.WriteLine("Subtraction: " + intCalculator.PerformOperation(5, 3, intCalculator.Subtract));
        Console.WriteLine("Multiplication: " + intCalculator.PerformOperation(5, 3, intCalculator.Multiply));
        Console.WriteLine("Division: " + intCalculator.PerformOperation(5, 3, intCalculator.Divide));

        Calculator<double> doubleCalculator = new Calculator<double>();
        Console.WriteLine("Addition: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Add));
        Console.WriteLine("Subtraction: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Subtract));
        Console.WriteLine("Multiplication: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Multiply));
        Console.WriteLine("Division: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Divide));
    }
}
