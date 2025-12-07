using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static double CalculateCost(int numCoffeeBags)
        {
            if (numCoffeeBags < 6)
                return numCoffeeBags * 36;
            else if (numCoffeeBags < 16)
                return numCoffeeBags * 34.5;
            else
                return numCoffeeBags * 32.7;
        }

        static void Main(string[] args)
        {
            char choice;

            // Keep The Loop Running Until The Choice Is y/Y
            do
            {

                // Input Customer Name
                Console.Write("Enter Customer Full Name: ");
                string customerName = Console.ReadLine();

                // Input Number Of Coffee Bags
                Console.Write("Enter Number Of Coffee Bags (1-200): ");
                int numCoffeeBags;
                while (!int.TryParse(Console.ReadLine(), out numCoffeeBags))
                {
                    Console.Write("Invalid input, enter a number: ");
                }


                // Keep Re-Entering Number Of Coffee Bags
                // If Until User Enters Invalid Value
                while (numCoffeeBags < 1 || numCoffeeBags > 200)
                {
                    Console.WriteLine("Value Must Be Between 1 And 200!");
                    Console.Write("Re-Enter Number Of Coffee Bags (1-200): ");
                    numCoffeeBags = Int32.Parse(Console.ReadLine());
                }

                // Input If The Customer Is A Reseller
                Console.Write("Is Customer A Reseller? (y/Y For Yes): ");
                choice = Console.ReadLine().ToLower()[0];
                bool isReseller = false;
                if (choice == 'y')
                {
                    isReseller = true;
                }


                // Compute Bill

                double totalCost = CalculateCost(numCoffeeBags);


                // Compute Discount
                double discount = 0.0;

                if (isReseller)
                {
                    discount = totalCost * 0.25;
                }

                // Print Bill
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("------------------- BILL -------------------");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Customer Name: {0}", customerName);
                Console.WriteLine("Number Of Coffee Bags: {0}", numCoffeeBags);
                Console.WriteLine("Total Cost Of Bags: {0:C}", totalCost);
                Console.WriteLine("Discount: {0:C}", discount);
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Amount Payable: {0:C}", totalCost - discount);
                Console.WriteLine("--------------------------------------------");



                // Input User Choice
                Console.Write("Input Y/y To Continue Or Any Other Key To Exit: ");

                // Get First Letter Of Choice
                choice = Console.ReadLine().ToLower()[0];
                Console.WriteLine();
            } while (choice == 'y');
        }
    }
}
