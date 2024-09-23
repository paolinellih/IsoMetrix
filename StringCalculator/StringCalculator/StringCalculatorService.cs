using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculatorService : IStringCalculator
    {
        private readonly string negativeErrorMessage = "Negatives not allowed: ";

        public int Add(string numbers)
        {
            numbers = numbers.Trim();

            if (string.IsNullOrEmpty(numbers))
            {
                return 0; // For an emptystring it will return 0
            }

            // Get numbers string checking delimiters
            var numberStrings = GetNumbersString(numbers);

            var negatives = new List<int>();  // To store any negative numbers
            int sum = 0;

            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString, out int number))
                {
                    if (number < 0)
                    {
                        negatives.Add(number);
                    }
                    else if (number <= 1000)
                    {
                        sum += number;
                    }
                }
            }

            if (negatives.Any())
            {
                throw new ArgumentException(negativeErrorMessage + string.Join(",", negatives));
            }

            return sum;
        }

        private string[] GetNumbersString(string numbers)
        {
            string[] delimiters = { ",", "\n" }; // Default delimiters
            var customDelimiters = new List<string>();
            string modifiedInput = numbers;

            // Check for custom delimiter
            if (numbers.StartsWith("//"))
            {
                int newlineIndex = numbers.IndexOf("\n");
                string delimiterPart = numbers.Substring(2, newlineIndex - 2);
                modifiedInput = numbers.Substring(newlineIndex + 1);

                // Find all multi-character delimiters within square brackets
                var matches = Regex.Matches(delimiterPart, @"\[(.*?)\]");
                foreach (Match match in matches)
                {
                    customDelimiters.Add(match.Groups[1].Value);
                }

                // Check if there is a single character delimiter (not in brackets)
                if (!delimiterPart.Contains("["))
                {
                    customDelimiters.Add(delimiterPart[0].ToString());
                }
            }

            // Combine default and custom delimiters
            delimiters = delimiters.Concat(customDelimiters).ToArray();

            // Replace all delimiters with a common one for splitting
            string pattern = string.Join("|", delimiters.Select(d => Regex.Escape(d)));
            string[] numberStrings = Regex.Split(numbers, pattern);

            return numberStrings;
        }
    }
}