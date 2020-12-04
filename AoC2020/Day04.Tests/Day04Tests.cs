using System.IO;
using Day04.Extensions;
using NUnit.Framework;

namespace Day04.Tests
{
    public class Day04Tests
    {
        [Test]
        public void Day04P01()
        {
            // Valid - Invalid - Valid - Invalid
            var expected = 2;
            var actual = File.ReadAllText("input_p01.txt").ValidPassportPart01();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Day04P02()
        {
            // Valid - Invalid - Valid - Valid - Invalid - Invalid - Invalid - Valid
            var expected = 4;
            var actual = File.ReadAllText("input_p02.txt").ValidPassportPart02();
            Assert.AreEqual(expected, actual);
        }
    }
}