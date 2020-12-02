using System;

namespace AoCLib.ValueObjects
{
    public class PasswordValueObjectException : Exception
    {
        public PasswordValueObjectException(string line, Exception ex)
            : base($"Password value object \"{line}\" is invalid", ex)
        {
            
        }
    }
}