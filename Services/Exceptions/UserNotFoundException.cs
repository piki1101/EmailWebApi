using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class UserNotFoundException: Exception
    {
        protected UserNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
