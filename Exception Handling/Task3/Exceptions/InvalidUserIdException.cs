using System;

namespace Task3.Exceptions
{
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException(string message)
            : base(message) { }
    }
}
