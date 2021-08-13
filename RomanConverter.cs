using System;
using System.Linq;
using System.Collections.Generic;

namespace DotRoman
{
    public class RomanConverter
    {
        private static readonly Dictionary<char, int> RomanNumeral = new Dictionary<char, int> {
            { 'I',  1    },
            { 'V',  5    },
            { 'X',  10   },
            { 'L',  50   },
            { 'C',  100  },
            { 'D',  500  },
            { 'M',  1000 }
        };

        private static readonly Dictionary<char, char> ValidCombinations = new Dictionary<char, char> {
            { 'I', '\0' },
            { 'V', 'I' },
            { 'X', 'I' },
            { 'L', 'X' },
            { 'C', 'X' },
            { 'D', 'C' },
            { 'M', 'C' }
        };
        public static int ConvertLiteral(string romanLiteral)
        {
            int result = 0;

            // Parsing roman literal string char by char
            for (int i = 0; i < romanLiteral.Length; ++i)
            {
                if ((i > 0 && romanLiteral.Length >= 2) && RomanNumeral[romanLiteral[i]] > RomanNumeral[romanLiteral[i - 1]])
                {
                    if (ValidCombinations[romanLiteral[i]] != romanLiteral[i - 1])
                    {
                        Console.Error.WriteLine("Syntax error.");
                        System.Environment.Exit(1);
                    }
                    
                    result -= RomanNumeral[romanLiteral[i - 1]];
                    result += (RomanNumeral[romanLiteral[i]] - RomanNumeral[romanLiteral[i - 1]]);
                }
                else
                    result += RomanNumeral[romanLiteral[i]];
            }
            return result;
        }
    }
}