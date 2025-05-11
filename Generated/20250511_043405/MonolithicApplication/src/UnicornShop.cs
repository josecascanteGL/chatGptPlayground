using System;

namespace CommentedCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of integers
            int[] numbers = { 3, 7, 9, 2, 5 };

            // Iterate over the elements in the array
            foreach (int number in numbers)
            {
                // Print each element in the array
                Console.WriteLine(number);
            }

            // Calculate and print the sum of all elements in the array
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine("Sum: " + sum);

            // Calculate and print the average of all elements in the array
            double average = (double)sum / numbers.Length;
            Console.WriteLine("Average: " + average);
        }
    }
}