using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace test.Exceptions
{
  [Serializable]
  public class UnAuthorizedException : Exception
  {
    public UnAuthorizedException() { }
    public UnAuthorizedException(string message) : base(message) { }
    public UnAuthorizedException(string message, Exception inner) : base(message, inner) { }
    protected UnAuthorizedException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) { }
  }
}
