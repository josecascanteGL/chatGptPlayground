using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Initialize an array of integers with some values
            int[] numbers = { 5, 2, 8, 10, 3 };

            // Iterate through the array to find and print the maximum value
            int max = numbers[0]; // Assume the first element is the maximum
            for (int i = 1; i < numbers.Length; i++) // Start from the second element
            {
                if (numbers[i] > max) // Check if the current element is greater than the current maximum
                {
                    max = numbers[i]; // If true, update the maximum value
                }
            }

            // Print the maximum value found in the array
            Console.WriteLine("The maximum value is: " + max);
        }
    }
}