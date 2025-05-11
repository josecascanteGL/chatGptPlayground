// Import necessary libraries
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize variables
            int number = 5;
            int factorial = 1;

            // Calculate the factorial of the given number
            for (int i = 1; i <= number; i++)
            {
                // Multiply the current factorial with the current counter value
                factorial *= i;
            }

            // Print the factorial of the number
            Console.WriteLine("Factorial of " + number + " is: " + factorial);
        }
    }
}