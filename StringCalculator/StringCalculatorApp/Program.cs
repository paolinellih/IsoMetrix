using System;

namespace StringCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of your StringCalculator
            var calculator = new StringCalculator.StringCalculatorService();

            // Manually pass a string to the Add method
            Console.WriteLine("Enter numbers to calculate: ");
            var input = Console.ReadLine();

            input = input.Replace("\\n", "\n"); // Replace escaped newline with actual newline in order to test it manually

            Console.WriteLine($"You entered: '{input}'");
            try
            {
                Console.WriteLine($"Input: {input}");

                var result = calculator.Add(input);
                Console.WriteLine($"The result is: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
