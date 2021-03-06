using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Utilities
{
  public interface ILogger : IDisposable
  {
    void Write(string log);
    void WriteLine(string log);
  }

  public class SimpleConsoleLogger : ILogger
  {
    public void Dispose()
    {

    }

    public void Write(string log)
    {
      Console.Write(log);
    }

    public void WriteLine(string log)
    {
      Console.WriteLine(log);
    }
  }

  public class SimpleFileLogger : ILogger
  {
    private StreamWriter writer;

    public SimpleFileLogger()
    {
      string dataPath = "";
      writer = File.AppendText(dataPath);
      writer.WriteLine("====================================================================");
      writer.WriteLine("=========== " + DateTime.Now.ToShortDateString() + " ===============");
    }

    public void Dispose()
    {
      writer.Close();
      writer.Dispose();
    }

    public void Write(string log)
    {
      writer.Write(log);
    }

    public void WriteLine(string log)
    {
      writer.WriteLine(log);
    }
  }

  public class NullLoggger : ILogger
  {
    public void Write(string log)
    {
    }

    public void WriteLine(string log)
    {
    }

    public void Dispose()
    {
    }
  }
}
