using System;
using System.Collections.Generic;

namespace JohannasLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Beep! Jag tar exakt ett argument.");
                return;
            }

            HighlightNumberChunks(args[0]);
        }

        static void HighlightNumberChunks(string mixedString)
        {
            long sum = 0;

            for (int indexInitium = 0; indexInitium < mixedString.Length; indexInitium++)
            {
                int indexFinito = LocateChunk(indexInitium, mixedString);

                if (indexFinito > 0)
                {
                    PrintColoredMix(mixedString, indexInitium, indexFinito);
                    sum += long.Parse(mixedString.Substring(indexInitium, indexFinito - indexInitium + 1));
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total = " + sum);
        }

        static int LocateChunk(int indexInitium, string mixedString)
        {
            int indexFinito = 0;
            char firstChar = mixedString[indexInitium];

            for (int i = indexInitium + 1; i < mixedString.Length; i++)
            {
                char currentChar = mixedString[i];

                if (IsDigit(currentChar))
                {
                    if (firstChar == currentChar)
                    {
                        indexFinito = i;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return indexFinito;
        }

        static void PrintColoredMix(string mixedString, int indexInitium, int indexFinito)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            const ConsoleColor baseColor = ConsoleColor.DarkYellow;

            if (indexInitium > 0)
            {
                Console.ForegroundColor = baseColor;
                Console.Write(mixedString.Substring(0, indexInitium));
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(mixedString.Substring(indexInitium, indexFinito - indexInitium + 1));

            Console.ForegroundColor = baseColor;
            Console.Write(mixedString.Substring(indexFinito + 1));

            Console.ForegroundColor = oldColor;
            Console.WriteLine();
        }

        static bool IsDigit(char currentChar)
        {
            string currentCharAsString = currentChar.ToString();
            int parsedDigit;
            return int.TryParse(currentCharAsString, out parsedDigit);
        }
    }
}