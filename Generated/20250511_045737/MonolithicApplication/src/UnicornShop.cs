
using System;

class Program
{
    static void Main()
    {
        // Define an array of integers
        int[] numbers = { 2, 4, 6, 8, 10 };
        
        // Initialize a variable to store the sum of the elements in the array
        int sum = 0;
        
        // Iterate through each element in the array
        foreach (int number in numbers)
        {
            // Add the current element to the sum
            sum += number;
        }
        
        // Print out the sum of the elements in the array
        Console.WriteLine("The sum of the numbers is: " + sum);
    }
}