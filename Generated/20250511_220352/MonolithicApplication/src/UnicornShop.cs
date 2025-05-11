using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10; // Set the number of Fibonacci numbers to generate
            int a = 0, b = 1, c; // Initialize variables to store the current, next, and sum of Fibonacci numbers

            Console.WriteLine("First " + n + " Fibonacci numbers:");

            // Loop to generate and print the first n Fibonacci numbers
            for (int i = 0; i < n; i++)
            {
                // Print the current Fibonacci number
                Console.WriteLine(a);
                // Calculate the sum of the current and next Fibonacci numbers
                c = a + b;
                // Update the current and next Fibonacci numbers for the next iteration
                a = b;
                b = c;
            }
        }
    }
}