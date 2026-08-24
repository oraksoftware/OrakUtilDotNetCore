namespace OrakUtilDotNetCore.FiConfig;

using System;
using System.Configuration;
using System.Drawing;

public static class FiAppConfig
{
  public static bool boTestMode; // { get; set; }
  public static IFiConfig? fiConfig; // { get; set; }
  public static IFiLogger? fiLog; // { get; set; }

  public static void ConvertTestModeTrue()
  {
    boTestMode = true;
  }

  public static bool getBoTestModeNtn()
  {
    if (boTestMode==null) return false;
    return boTestMode;
  }


  public static string GetConnStringWitTest(string txProfile)
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