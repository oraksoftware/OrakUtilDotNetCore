namespace OrakUtilDotNetCore.FiConfig;

using System;
using System.Configuration;
using System.Drawing;

public static class FiAppConfig
{
  public static bool boTestMode = false;
  public static IFiConfigManager? fiConfig;
  public static IFiLogManager? fiLog;

  public static void ConvertTestModeTrue()
  {
    boTestMode = true;
  }


  public static string GetConnStringWthTest(string txProfile)
  {
    // config dosyasından key'den sonra test ile geleni alması için.
    if (boTestMode == true) txProfile = txProfile + "-test";
    return fiConfig?.GetConnString(txProfile);
  }

  public static string? GetConnString(string txProfile)
  {
    // config dosyasından key'den sonra test ile geleni alması için. ???review
    if (boTestMode == true) txProfile = txProfile + "-test";

    return fiConfig?.GetConnString(txProfile);
  }

  public static string? GetBaseUrl(string txProfile)
  {
    // config dosyasından key'den sonra test ile geleni alması için.
    //if (boTestMode == true) txProfile = txProfile + "-test";

    return fiConfig?.GetApiUrl(txProfile);
  }

  public static void LogDebug(string message)
  {
    fiLog?.Debug(message);
  }

}