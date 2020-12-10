using System;
using System.IO;
using System.Linq;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            var vals = File.ReadAllLines("input.txt").Select(long.Parse).ToArray();
            long invalidNumber = -1;
            int invalidIndex = -1;
            var conditionMet = false;
            var previousNumbers = 25;
            for (int i = previousNumbers; i < vals.Length; i++)
            {
                for (int j = i - previousNumbers; j < i - 1; j++)
                {
                    if (conditionMet) break;
                    for (int k = j + 1; k < i; k++)
                    {
                        if (vals[i] == vals[j] + vals[k])
                        {
                            conditionMet = true;
                            break;
                        }
                    }
                }

                if (!conditionMet)
                {
                    invalidNumber = vals[i];
                    invalidIndex = i;
                    break;
                }
                conditionMet = false;
            }
            Console.WriteLine($"Result for day 09 part 1 task is {invalidNumber}");

            long acc = 0;
            long min = int.MaxValue;
            long max = int.MinValue;
            for (int i = 0; i < invalidIndex - 1; i++)
            {
                acc += vals[i];
                if (vals[i] < min)
                {
                    min = vals[i];
                }
                if (vals[i] > max)
                {
                    max = vals[i];
                }
                for (int j = i + 1; j < invalidIndex; j++)
                {
                    if (vals[j] < min)
                    {
                        min = vals[j];
                    }
                    if (vals[j] > max)
                    {
                        max = vals[j];
                    }
                    acc += vals[j];
                    if (acc == invalidNumber)
                    {
                        conditionMet = true;
                        break;
                    }
                }

                if (conditionMet) break;
                acc = 0;
                min = int.MaxValue;
                max = int.MinValue;
            }
            Console.WriteLine($"Result for day 09 part 2 task is {min + max}");
        }
    }
}