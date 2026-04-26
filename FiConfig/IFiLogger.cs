namespace OrakUtilDotNetCore.FiConfig
{
  public interface IFiLogger
  {
    void Debug(string message);

    void Error(string message);

    //void LogMessage(string message,Type refType);
  }


}