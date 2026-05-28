using OrakUtilDotNetCore.FiCore;

namespace OrakUtilDotNetCore.FiContainer
{
  /// <summary>
  /// Request yapılırken gönderilen temel bilgiler : kullanıcı vs.
  /// </summary>
  public class FiReq
  {
    public string? frTxProfile { get; set; }
    public string? frTxUser { get; set; }
    public string? frTxPass { get; set; }
    public string? frTxToken { get; set; }
    public Fkb? frFkbParams { get; set; }

    public bool? frBoShowDoc { get; set; }
    public string? frTxDb { get; set; }

    // tek değer gönderenler için
    public string? frTxValue { get; set; }
    public int? frLnValue { get; set; }

    public string GetTxProfile()
    {
      return frTxProfile;
    }

    public string GetDbConnProfile()
    {
      return frTxProfile + (FiString.IsEmpty(frTxDb)?"": "-" + frTxDb);
    }

    public string GetConnProfile()
    {
      return frTxProfile??"";
    }

  }
}