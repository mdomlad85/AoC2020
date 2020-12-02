using AoCLib.ValueObjects;
using Xunit;

namespace AoCLib.Tests.ValueObjects
{
    public class PasswordValueObjectTests
    {
        [Fact]
        public void ShouldHaveCorrectAddressParts()
        {
            var passValueObject = PasswordValueObject.For("16-20 h: hhhjthhhtphchpkhmhhh");
            Assert.Equal(expected: 16, actual: passValueObject.FirstPosition);
            Assert.Equal(20, passValueObject.SecondPosition);
            Assert.Equal('h', passValueObject.Character);
            Assert.Equal("hhhjthhhtphchpkhmhhh", passValueObject.PasswordValue);
        }

        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const string expected = "16-20 h: hhhjthhhtphchpkhmhhh";

            var actual = PasswordValueObject.For(expected);
            
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string expected = "16-20 h: hhhjthhhtphchpkhmhhh";

            var actual = PasswordValueObject.For(expected);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExplicitConversionToStringResultsInCorrectString()
        {
            var passValueObject = (PasswordValueObject)"16-20 h: hhhjthhhtphchpkhmhhh";
            
            Assert.Equal(expected: 16, actual: passValueObject.FirstPosition);
            Assert.Equal(20, passValueObject.SecondPosition);
            Assert.Equal('h', passValueObject.Character);
            Assert.Equal("hhhjthhhtphchpkhmhhh", passValueObject.PasswordValue);
        }

        [Fact]
        public void ShouldThrowAddressInvalidExceptionForInvalidAddress()
        {
            Assert.Throws<PasswordValueObjectException>(() => (PasswordValueObject)"16-.20 h: hhhjthhhtphchpkhmhhh");
        }
    }
}