using System;
using System.Text;

namespace DiamondKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1
                || args[0].Length != 1)
            {
                Console.WriteLine("Input is not in the correct format!");
                return;
            }
            var alphabet = args[0][0];

            if(alphabet < 'A' || alphabet > 'z')
            {
                Console.WriteLine("Input is not an alphabet!");
                return;
            }

            var diamond = new StringBuilder();
            var start = 'A';
            if (alphabet > 'Z')
            {
                start = 'a';
            }
                
            for(var i = start; i <= alphabet - 1; i++)
            {
                diamond.Append(BuildLine(i, alphabet, start));
            }

            //Get reverse
            var reverse = string.Empty;
            if(diamond.Length > 0) // check applied if the input is 'A' or 'a' then array will be empty
            {
                var chArray = diamond.ToString().ToCharArray();
                Array.Reverse(chArray);
                reverse = new string(chArray);
                reverse = reverse.Remove(0, 1); //Remove first newline character
            }

            //Append for alphabet
            diamond.Append(BuildLine(alphabet, alphabet, start));

            //Append Reverse
            diamond.Append(reverse);
            Console.WriteLine(diamond.ToString());
        }

        static string BuildLine(char character, char alphabet, char start)
        {
            var sb = new StringBuilder();
            
            var endSpace = new string(' ', alphabet - character);
            sb.Append(endSpace);
            sb.Append(character);

            if(character > start)
            {
                var midSpace = new string(' ', 2 * (character - start - 1) + 1);
                sb.Append(midSpace);
                sb.Append(character);
            }
            
            sb.Append(endSpace);
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
