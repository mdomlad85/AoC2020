using System.IO;
using System.Linq;
using AoCLib.Extensions;
using AoCLib.Models;
using NUnit.Framework;
using Xunit;

namespace Day03
{
    public class Day03
    {
        [Fact]
        public void Day03P01()
        {
            var expected = 265;
            var lines = File.ReadLines("input.txt").ToArray();
            var actual = lines.CheckSlopeTrees(new Slope(3, 1));
            Assert.Equals(expected, actual);
        }
        
        [Fact]
        public void Day03P02()
        {
            var expected = 3154761400L;
            var lines = File.ReadLines("input.txt").ToArray();
            var slopes = new []
            {
                new Slope(1, 1),
                new Slope(3, 1),
                new Slope(5, 1),
                new Slope(7, 1),
                new Slope(1, 2),
            };

            var actual = 1L;
            foreach (var slope in slopes)
            {
                actual *= lines.CheckSlopeTrees(slope);
            }
            Assert.Equals(expected, actual);
        }
    }
}