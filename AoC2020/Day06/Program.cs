using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var answers = File.ReadAllLines("input.txt");

            var part1Count = 0;
            var groupCount = 0;
            var groupAnswers = new HashSet<char>();
            
            for (int i = 0; i < answers.Length; i++)
            {
                var answer = answers[i];
                if (string.IsNullOrWhiteSpace(answer))
                {
                    part1Count += groupCount;
                    groupCount = 0;
                    groupAnswers.Clear();
                    continue;
                }

                foreach (var c in answer)
                {
                    if (groupAnswers.Add(c))
                    {
                        groupCount++;
                    }
                }

                if (i == answers.Length - 1)
                {
                    part1Count += groupCount;
                }
            }
            Console.WriteLine($"Sum of counts part 1: {part1Count}");

            var part2Count = 0;
            var groupNoCount = 0;
            var groupAnswerCounts = new Dictionary<char, int>();
            
            for (int i = 0; i < answers.Length; i++)
            {
                var answer = answers[i];
                if (string.IsNullOrWhiteSpace(answer))
                {
                    foreach (var cnt in groupAnswerCounts.Values)
                    {
                        if (cnt == groupNoCount) part2Count++;
                    }
                    groupNoCount = 0;
                    groupAnswerCounts.Clear();
                    continue;
                }

                groupNoCount++;

                foreach (var c in answer)
                {
                    groupAnswerCounts[c] = groupAnswerCounts.ContainsKey(c) ? groupAnswerCounts[c] + 1 : 1;
                }

                if (i == answers.Length - 1)
                {
                    foreach (var cnt in groupAnswerCounts.Values)
                    {
                        if (cnt == groupNoCount) part2Count++;
                    }
                }
            }
            Console.WriteLine($"Sum of counts part 2: {part2Count}");
        }
    }
}