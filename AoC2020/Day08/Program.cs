using System;
using System.Collections.Generic;
using System.IO;

namespace Day08
{
    static class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Result for day 08 part 1 task is {Part01(lines)}");
            Console.WriteLine($"Result for day 08 part 2 task is {Part02(lines)}");
        }
        
        private class Command
        {
            public string Name { get; set; }
            public int Value { get; }
            public bool Visited { get; set; }
            public string ChangedFrom { get; set; }

            public Command(string name, int value)
            {
                Name = name;
                Value = value;
            }
        }

        private static int Part01(string[] lines)
        {
            var commands = ParseLinesList(lines);

            int index = 0;
            var acc = 0;
            while (index < commands.Count)
            {
                var command = commands[index];
                if (command.Visited)
                {
                    Console.WriteLine($"Infinite loop alert! Command {command.Name} at line {index} is already visited.");
                    break;
                }
                switch (command.Name)
                {
                    case "acc":
                        acc += command.Value;
                        index++;
                        break;
                    case "jmp":
                        index = index + command.Value;
                        break;
                    case "nop":
                        index++;
                        break;
                    default:
                        throw new ArgumentException($"Comand {command.Name} doesn't exists");
                }

                command.Visited = true;
            }

            return acc;
        }

        private static int Part02(string[] lines)
        {
            var commands = ParseLinesList(lines);

            int index = 0;
            var acc = 0;
            while (index < commands.Count )
            {
                var command = commands[index];
                if (command.Visited)
                {
                    foreach (var c in commands)
                    {
                        c.Visited = false;
                    }

                    Console.WriteLine($"Infinite loop alert! Command {command.Name} at line {index} is already visited.");
                    Console.WriteLine("Trying to repair...");
                    
                    acc = 0;
                    index = 0;
                    foreach (var c in commands)
                    {
                        if (!string.IsNullOrEmpty(c.ChangedFrom))
                        {
                            c.Name = c.ChangedFrom;
                            continue;
                        }

                        if (c.Name.Equals("nop") && c.Value > 0)
                        {
                            c.ChangedFrom = c.Name;
                            c.Name = c.Name.Replace("nop", "jmp");
                            break;
                        }

                        if (c.Name.Equals("jmp"))
                        {
                            c.ChangedFrom = c.Name;
                            c.Name = c.Name.Replace("jmp", "nop");
                            break;
                        }
                    }
                    
                    continue;
                }
                switch (command.Name)
                {
                    case "acc":
                        acc += command.Value;
                        index++;
                        break;
                    case "jmp":
                        index = index + command.Value;
                        break;
                    case "nop":
                        index++;
                        break;
                    default:
                        throw new ArgumentException($"Comand {command.Name} doesn't exists");
                }

                command.Visited = true;
            }

            return acc;
        }

        private static List<Command> ParseLinesList(this string[] lines)
        {
            var commands = new List<Command>();
            foreach (var line in lines)
            {
                var lineVals = line.Split(' ');
                var val = int.Parse(lineVals[1].Replace("+", "").Replace("-", "")) * (lineVals[1].StartsWith('+') ? 1 : -1);
                commands.Add(new Command(lineVals[0], val));
            }

            return commands;
        }
    }
}