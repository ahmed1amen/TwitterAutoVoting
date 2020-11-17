using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace test.Exceptions
{
  [Serializable]
  public class ReviewPageNotFoundException : Exception
  {
    public ReviewPageNotFoundException() { }
    public ReviewPageNotFoundException(string message) : base(message) { }
    public ReviewPageNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected ReviewPageNotFoundException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) { }
  }
}
