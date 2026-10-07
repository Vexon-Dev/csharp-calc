using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

Console.Write("###################################################");
Console.Write("\n                    Super calc                     ");
Console.Write("\n###################################################");
Thread.Sleep(1500);

Console.Write("\nPlease input the operation you want to perform (+, -, *, /) : ");
string input = Console.ReadLine();
if (!char.TryParse(input, out char operation))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("\nError! You can only input a single operation!");
    Console.ResetColor();
    Console.Write("\nPress any key to exit...");
    Console.ReadKey(intercept: true);
    return;
} else if (operation != '+' && operation != '-' && operation != '*' && operation != '/')
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"\nError! Cannot operate with {operation}!");
    Console.ResetColor();
    Console.Write("\nPress any key to exit...");
    Console.ReadKey(intercept: true);
    return;
}

Console.Write("\nPlease input the amount of numbers you want to use in the operation: ");
int numberAmount = int.Parse(Console.ReadLine());

List<double> numberList = new List<double>();

for (int i = 0; i < numberAmount; i++)
{
    Console.Write($"\nPlease input number {i + 1}: ");
    double number = double.Parse(Console.ReadLine());
    numberList.Add(number);
}

if (operation == '/' && numberList.Contains(0))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("\nError! Cannot divide by 0!");
    Console.ResetColor();
    Console.Write("\nPress any key to exit...");
    Console.ReadKey(intercept: true);
    return;
}

Console.Write($"\nThe numbers have been collected. There are {numberList.Count} numbers.");

double result;

if (operation == '-' || operation == '/')
{
    result = numberList[0];
} else if (operation == '*')
{
    result = 1;
}
else
{
    result = 0;
}

// foreach (double singleNumber in numberList)
// {
//     if (operation == '+')
//     {
//         result += singleNumber;
//     } else if (operation == '-')
//     {
//         result -= singleNumber;
//     } else if (operation == '*')
//     {
//         result *= singleNumber;
//     }  else if (operation == '/')
//     {
//         result /= singleNumber;
//     }
// }

if (operation == '+')
{
    foreach (double singleNumber in numberList)
    {
        result += singleNumber;
    }
} else if (operation == '-')
{
    foreach (double singleNumber in numberList.Skip(1))
    {
        result -= singleNumber;
    }
}  else if (operation == '*')
{
    foreach (double singleNumber in numberList)
    {
        result *= singleNumber;
    }
} else if (operation == '/')
{
    foreach (double singleNumber in numberList.Skip(1))
    {
        result /= singleNumber;
    }
}

Console.Write($"\nResult: {result}");
Console.Write("\nPress any key to exit...");
Console.ReadKey(intercept: true);
Environment.Exit(0);
