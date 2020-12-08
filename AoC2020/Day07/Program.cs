using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day07
{
    static class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Result for day 07 part 1 task is {Part01(lines)}");
            Console.WriteLine($"Result for day 07 part 2 task is {Part02(lines)}");
        }
        private static int Part01(string[] lines)
        {
            var outerBags = new Dictionary<string, HashSet<string>>();
            foreach (var line in lines) {
                var bag = ParseLine(line);

                foreach (var innerBag in bag.Value) {
                    if (!outerBags.ContainsKey(innerBag.Key)) {
                        outerBags[innerBag.Key] = new HashSet<string>();
                    }
                    outerBags[innerBag.Key].Add(bag.Key);
                }
            }
            
            IEnumerable<string> CountParents(string bag) {
                yield return bag;

                if (outerBags.ContainsKey(bag)) {
                    foreach (var container in outerBags[bag]) {
                        foreach (var bagT in CountParents(container)) {
                            yield return bagT;
                        }
                    }
                }
            }

            return CountParents("shiny gold bag").ToHashSet().Count - 1;
        }

        private static long Part02(string[] lines)
        {
            var innerBags = new Dictionary<string, List<KeyValuePair<string, int>>>();
            foreach (var line in lines) {
                var bag = ParseLine(line);
                innerBags[bag.Key] = bag.Value;
            }

            long CountRequiredBags(string bag) =>
                1 + (from child in innerBags[bag] select child.Value * CountRequiredBags(child.Key)).Sum();

            return CountRequiredBags("shiny gold bag") - 1;
        }

        /*
         * vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
         * faded blue bags contain no other bags.
         */
        private static KeyValuePair<string, List<KeyValuePair<string, int>>> ParseLine(string line){
            var key = Regex.Match(line, "^[a-z]+ [a-z]+ bag").Value;
            var val = Regex.Matches(line, "(\\d+) ([a-z]+ [a-z]+ bag)s?")
                    .Select(x => new KeyValuePair<string, int>(x.Groups[2].Value, int.Parse(x.Groups[1].Value)))
                    .ToList();
            return  new KeyValuePair<string, List<KeyValuePair<string, int>>>(key, val);
        }
    }
}