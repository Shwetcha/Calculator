using Calculator;
using System;


class Program
{
    static void Main(string[] args)
    {
        
        while (true)
        {
            Console.WriteLine("Please provide expression");
            string input = Console.ReadLine();

            if (input == null)
            {
                break;
            }

            try
            {
                double result = TextCalculator.Evaluate(input);
                Console.WriteLine("Result is " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
