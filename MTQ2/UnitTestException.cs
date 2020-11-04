
using System;
namespace MTQ2
{
    public class UnitTestException : Exception
    { 
        public UnitTestException( string message) :
          base(message)
        {
            Console.WriteLine(message);
        }

    }
}