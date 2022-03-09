using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods.Exceptions
{
    public class ExpressionException : Exception
    {
        public ExpressionException(string message) : base(message)
        {
        }
    }
}
