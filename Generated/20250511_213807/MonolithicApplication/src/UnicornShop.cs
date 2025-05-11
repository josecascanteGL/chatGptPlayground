using System;

public class Program
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        
        // Initialize a variable to store the sum of the numbers
        int sum = 0;
        
        // Loop through each element in the numbers array
        for (int i = 0; i < numbers.Length; i++)
        {
            // Add the current number to the sum
            sum += numbers[i];
        }
        
        // Calculate the average by dividing the sum by the total number of elements
        double average = (double)sum / numbers.Length;
        
        // Print out the sum and average
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Average: " + average);
    }
}