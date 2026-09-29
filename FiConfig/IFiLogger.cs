namespace OrakUtilDotNetCore.FiConfig
{
  public interface IFiLogger
  {
    void Debug(string message);

    void Error(string message);

    void DebugGen<T>(string message) where T : class;

    void ErrorGen<T>(string message) where T : class;

    //void LogMessage(string message,Type refType);
  }


}