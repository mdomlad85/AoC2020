using System.IO;
using System.Linq;
using Xunit;

namespace Day01
{
    public class Day01
    {
        [Fact]
        public void Day01P01()
        {
            uint expected = 703131;
            var lines = File.ReadLines("input.txt").ToArray();
            var actual = (
                from n1 in lines.Take(lines.Length - 1)
                from n2 in lines.Skip(1)
                where uint.Parse(n1) + uint.Parse(n2) == 2020
                select uint.Parse(n1) * uint.Parse(n2)
            ).First();
            Assert.Equal(expected, actual);
        }
        
        
        [Fact]
        public void Day01P02()
        {
            uint expected = 272423970;
            var lines = File.ReadLines("input.txt").ToArray();
            var actual = (
                from n1 in lines.Take(lines.Length - 2)
                from n2 in lines.Skip(1).Take(lines.Length - 1)
                from n3 in lines.Skip(2)
                where uint.Parse(n1) + uint.Parse(n2) + uint.Parse(n3) == 2020
                select uint.Parse(n1) * uint.Parse(n2) * uint.Parse(n3)
            ).First();
            Assert.Equal(expected, actual);
        }
    }
}