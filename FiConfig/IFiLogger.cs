namespace OrakUtilDotNetCore.FiConfig
{
  public interface IFiLogManager
  {
    void Debug(string message);

    void Error(string message);

    //void LogMessage(string message,Type refType);
  }


}