using Serilog;

namespace OrakUtilDotNetCore.FiLogs
{
  public static class FiLogUtil
  {
    public static ILogger GetLogger<T>()
    {
      return Log.ForContext<T>();
    }

    public static ILogger GetLogger(Type type)
    {
      return Log.ForContext(type);
    }
  }
}