using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    public class Prompts
    {
        public static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static int PromptForPuissance(string prompt)
        {
            int result;
            do
            {
                Console.WriteLine(prompt);
            } while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public static char PromptForType(string prompt)
        {
            char result;
            do
            {
                Console.WriteLine(prompt);
                result = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
            } while (result != 'v' && result != 'c');
            return result;
        }

        public static int PrompForNumero(string prompt)
        {
            string? input;
            int result;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (input?.Length < 4 || input?.Length > 6)
                {
                    Console.WriteLine("Input must be between 4 and 6 characters.");
                }
                else if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            while (input?.Length < 4 || input?.Length > 6 || !int.TryParse(input, out result));
            return result;
        }
    }
}
