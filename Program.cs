using System.Collections.Generic;

namespace DotRoman
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("usage: dot-roman [LITERAL]");
                return;
            }

            string romanLiteral = args[0];
            Console.WriteLine("Roman literal {0} is: {1}", romanLiteral, RomanConverter.ConvertLiteral(romanLiteral));
        }
    }
}