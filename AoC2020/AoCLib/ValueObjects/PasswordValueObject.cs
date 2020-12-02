using System;
using System.Collections.Generic;

namespace AoCLib.ValueObjects
{
    public class PasswordValueObject : ValueObject
    {
        public ushort FirstPosition { get; set; }
        public ushort SecondPosition { get; set; }
        public char Character { get; set; }
        public string PasswordValue { get; set; }

        protected PasswordValueObject()
        {
            
        }
        // Format
        // FirstPosition-SecondPosition Character: PasswordValue
        public static PasswordValueObject For(string line)
        {
            try
            {
                var retval = new PasswordValueObject();
                var rulesPassParts = line.Split(':');
                retval.PasswordValue = rulesPassParts[1].Trim();
                var rulesParts = rulesPassParts[0].Split(' ');
                retval.Character = rulesParts[1].Trim()[0];
                var rulesFromToParts = rulesParts[0].Split('-');
                retval.FirstPosition = ushort.Parse(rulesFromToParts[0]);
                retval.SecondPosition = ushort.Parse(rulesFromToParts[1]);
                return retval;
            }
            catch (Exception ex)
            {
                throw new PasswordValueObjectException(line, ex);
            }
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstPosition;
            yield return SecondPosition;
            yield return Character;
            yield return PasswordValue;
        }

        public static implicit operator string(PasswordValueObject passwordValueObject)
        {
            return passwordValueObject.ToString();
        }

        public static explicit operator PasswordValueObject(string line)
        {
            return For(line);
        }

        public override string ToString()
        {
            return $"{FirstPosition}-{SecondPosition} {Character}: {PasswordValue}";
        }
    }
}