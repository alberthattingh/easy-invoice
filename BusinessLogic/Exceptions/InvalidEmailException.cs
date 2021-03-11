using System;

namespace BusinessLogic.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
        {
        }

        public InvalidEmailException(string email) : base(
            $"The email provided is either invalid, or already exists in our database: {email}")
        {
        }
    }
}