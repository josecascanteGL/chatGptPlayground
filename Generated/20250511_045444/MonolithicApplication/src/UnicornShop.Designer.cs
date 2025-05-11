// Import necessary libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicornShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store Unicorn objects
            List<Unicorn> unicorns = new List<Unicorn>();

            // Add some Unicorn objects to the list
            unicorns.Add(new Unicorn("Rainbow", 1000));
            unicorns.Add(new Unicorn("Sunshine", 1200));
            unicorns.Add(new Unicorn("Sparkle", 1500));

            // Iterate through the list and print out each Unicorn's information
            foreach(Unicorn unicorn in unicorns)
            {
                Console.WriteLine("Name: " + unicorn.Name + ", Price: " + unicorn.Price);
            }
        }
    }

    // Class representing a Unicorn object with a name and price
    class Unicorn
    {
        public string Name { get; set; }
        public int Price { get; set; }

        // Constructor to initialize a Unicorn object with a name and price
        public Unicorn(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}