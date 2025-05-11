using System;

public class Program
{
    public static void Main()
    {
        int[] numbers = { 2, 4, 6, 8, 10 };
        int target = 16;
        bool found = false;

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }

        if (found)
        {
            Console.WriteLine("Target sum found in the array");
        }
        else
        {
            Console.WriteLine("Target sum not found in the array");
        }
    }
}