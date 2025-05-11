// Declare a public class named Program
public class Program
{
    // Define a static method named Main with string array parameter args
    static void Main(string[] args)
    {
        // Declare and initialize an integer variable named sum with a value of 0
        int sum = 0;

        // Create a for loop that iterates from 1 to 10
        for (int i = 1; i <= 10; i++)
        {
            // Add the current value of i to the sum variable
            sum += i;
        }

        // Print the final sum value to the console
        Console.WriteLine("The sum of numbers from 1 to 10 is: " + sum);
    }
}