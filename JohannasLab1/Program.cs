using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;

namespace JohannasLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            HighlightNumberChunks("29535123p48723487597645723645");
            HighlightNumberChunks("jjjjj");
            HighlightNumberChunks("44");
        }

        static void HighlightNumberChunks(string mixedString)
        {
            double sum = 0;

            for (int i = 0; i < mixedString.Length; i++)
            {
                int indexInitium = i;
                int indexFinito = LocateChunk(i, mixedString);

                if (indexFinito > 0)
                {
                    PrintColoredMix(mixedString, indexInitium, indexFinito);
                    sum += double.Parse(mixedString.Substring(indexInitium, indexFinito - indexInitium + 1));
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total = " + sum);
            Console.WriteLine();
        }

        static int LocateChunk(int i, string mixedString)
        {
            int indexFinito = 0;
            for (int j = i + 1; j < mixedString.Length; j++)
            {
                char firstChar = mixedString[i];
                char currentChar = mixedString[j];

                if (IsDigit(currentChar))
                {
                    if (firstChar == currentChar)
                    {
                        indexFinito = j;
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
            if (indexInitium > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(mixedString.Substring(0, indexInitium));
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(mixedString.Substring(indexInitium, indexFinito - indexInitium + 1));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(mixedString.Substring(indexFinito + 1));
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