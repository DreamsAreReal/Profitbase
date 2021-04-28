using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Profitbase.Wrapper.Exceptions
{
    [Serializable]
    public class LoginIncorrectException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public LoginIncorrectException()
        {
        }

        public LoginIncorrectException(string message) : base(message)
        {
        }

        public LoginIncorrectException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LoginIncorrectException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
