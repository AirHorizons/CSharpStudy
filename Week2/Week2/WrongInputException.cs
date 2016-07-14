using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class WrongInputException : Exception
    {
        public WrongInputException() { }
        public WrongInputException(string message) : base(message) { }
    }
}
