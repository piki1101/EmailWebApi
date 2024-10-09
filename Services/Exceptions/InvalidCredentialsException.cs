using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    [Serializable]
    public class InvalidCredentialsException : Exception
    {
        protected InvalidCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidCredentialsException(string message) : base(message)
        {
        }
    }
}
