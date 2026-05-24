using OrakUtilDotNetCore.FiCollections;
using OrakUtilDotNetCore.FiDataContainer;
using System.Text;

namespace OrakUtilDotNetCore.FiContainer
{
  /// <summary>
  /// Prefix: fs
  /// </summary>
  public class FiRes
  {
    public bool? fsBoTknValid { get; set; }

    public bool? fsBoResult { get; set; }

    public object fsRefFdr { get; set; }

    public object fsRefValue { get; set; }

    public string fsTxVer { get; set; }

    public string fsTxMessage { get; set; }

    public int? fsLnErrorCode { get; set; }

    public string fsTxToken { get; set; }

    // Methods

    public void SetErrorMeta(FiMeta fiMeta)
    {
      this.fsTxMessage = fiMeta.ftTxKey;
      this.fsLnErrorCode = fiMeta.ftLnKey;
    }
    public void AddTxMessage(string txMess)
    {
      this.fsTxMessage = this.fsTxMessage + " " + txMess;
    }

    public void AddTxMessageGerekliAlanlar(FicList ficList)
    {
      StringBuilder sb = new StringBuilder();

      foreach (var fiCol in ficList)
      {
        sb.Append(fiCol.fcTxFieldName + ",");
      }
      sb.Append(" Alanları Gereklidir.");

      this.fsTxMessage = this.fsTxMessage + " " + sb.ToString();
    }

    public void SetFdrResultToFir(Fdr fdr)
    {
      this.fsRefFdr = DtoFdr1.GenFdr1(fdr);
      this.fsBoResult = fdr.IsTrueBoResult();
    }

    public object getAsDtoObject()
    {
      return DtoFdr1.GenFiRes(this);
    }

  }
}