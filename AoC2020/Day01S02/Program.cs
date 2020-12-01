using System;
using System.IO;
using System.Linq;

namespace Day01S02
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt").ToArray();
            var result = (from n1 in lines
                from n2 in lines
                from n3 in lines
                where uint.Parse(n1) + uint.Parse(n2) + uint.Parse(n3) == 2020
                select uint.Parse(n1) * uint.Parse(n2) * uint.Parse(n3)).First();
            Console.WriteLine($"Result is: {result}");
        }
    }
}