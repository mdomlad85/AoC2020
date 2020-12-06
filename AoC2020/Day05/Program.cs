using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var seatCodes = File.ReadAllLines("input.txt");
            int maxSeatId = Int32.MinValue;
            var seatIds = new SortedSet<int>();

            foreach (var seatCode in seatCodes)
            {
                const char front = 'F';
                const char back = 'B';
                int rowStart = 0;
                int rowLen = 7;
                int row = 0;
                int rowUpperBound = 128;

                foreach (var rowCodeChar in seatCode.Substring(rowStart, rowLen))
                {
                    int range = (rowUpperBound - row) / 2;
                    switch (rowCodeChar)
                    {
                        case front:
                            rowUpperBound = row + range;
                            break;
                        case back:
                            row = rowUpperBound - range;
                            break;
                        default:
                            throw new Exception(
                                $"Row code char has wrong value (possible vals: F,B given: {rowCodeChar}");
                    }
                }


                const char left = 'L';
                const char right = 'R';
                int columnStart = 7;
                int columnLen = 3;
                int column = 0;
                int columnUpperBound = 8;

                foreach (var colCodeChar in seatCode.Substring(columnStart, columnLen))
                {
                    int range = (columnUpperBound - column) / 2;
                    switch (colCodeChar)
                    {
                        case left:
                            columnUpperBound = column + range;
                            break;
                        case right:
                            column = columnUpperBound - range;
                            break;
                        default:
                            throw new Exception(
                                $"Column code char has wrong value (possible vals: L,R given: {colCodeChar}");
                    }
                }

                int seatId = row * 8 + column;
                seatIds.Add(seatId);

                if (seatId > maxSeatId)
                {
                    maxSeatId = seatId;
                }
            }

            Console.WriteLine($"Solution for part 1: Max seat id is {maxSeatId}");

            int mySeatId = -1;
            var seatIdsList = seatIds.ToList();
            for (int i = 0; i < seatIdsList.Count - 1; i++)
            {
                if (seatIdsList[i + 1] - seatIdsList[i] == 2)
                {
                    mySeatId = seatIdsList[i] + 1;
                    break;
                }
            }
            Console.WriteLine($"Solution for part 2: My seat id is {mySeatId}");
        }
    }
}