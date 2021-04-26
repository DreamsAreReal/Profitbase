using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Profitbase.Wrapper.Exceptions
{
    [Serializable]
    public class CrsfTokenParseException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //
        public string PageSource => _pageSource;
        private string _pageSource;
        public CrsfTokenParseException()
        {
        }

        public CrsfTokenParseException(string pageSource) : base(pageSource)
        {
            _pageSource = pageSource;
        }

        public CrsfTokenParseException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CrsfTokenParseException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
