using System.IO;
using System.Linq;
using AoCLib.ValueObjects;
using Xunit;

namespace Day02
{
    public class Day02
    {
        [Fact]
        public void Day02P01()
        {
            var expected = 474;
            var lines = File.ReadLines("input.txt").ToArray();
            var actual = 0;

            foreach (var line in lines)
            {
                var passValueObject = PasswordValueObject.For(line);
                ushort counter = 0;
                foreach (var c in passValueObject.PasswordValue)
                {
                    if (c == passValueObject.Character) counter++;
                    if (counter > passValueObject.SecondPosition) break;
                }

                if (counter <= passValueObject.SecondPosition && counter >= passValueObject.FirstPosition) actual++;
            }

            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void Day02P02()
        {
            var expected = 745;
            var lines = File.ReadLines("input.txt").ToArray();
            var actual = 0;

            foreach (var line in lines)
            {
                var passValueObject = PasswordValueObject.For(line);
                if ((passValueObject.Character == passValueObject.PasswordValue[passValueObject.FirstPosition - 1] && 
                    passValueObject.Character != passValueObject.PasswordValue[passValueObject.SecondPosition - 1]) ||
                    (passValueObject.Character != passValueObject.PasswordValue[passValueObject.FirstPosition - 1] && 
                     passValueObject.Character == passValueObject.PasswordValue[passValueObject.SecondPosition - 1]))
                {
                    actual++;
                }
            }

            Assert.Equal(expected,actual);
        }
    }
}