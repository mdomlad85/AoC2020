using System;
using System.IO;
using Day04.Extensions;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Valid Passports part 01: {File.ReadAllText("input.txt").ValidPassportPart01()}");
            Console.WriteLine($"Valid Passports part 02: {File.ReadAllText("input.txt").ValidPassportPart02()}");
        }
    }
}