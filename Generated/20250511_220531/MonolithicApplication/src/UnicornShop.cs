using System;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input the number to check for prime
            Console.Write("Enter a number to check if it is prime: ");
            int number = Convert.ToInt32(Console.ReadLine());

            bool isPrime = true;

            // Check if the number is divisible by any number from 2 to its square root
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            // Check and output the result
            if (number <= 1)
            {
                isPrime = false;
            }

            if (isPrime)
            {
                Console.WriteLine(number + " is a prime number.");
            }
            else
            {
                Console.WriteLine(number + " is not a prime number.");
            }
        }
    }
}