using OrakUtilDotNetCore.FiDataContainer;

namespace OrakUtilDotNetCore.FiContainer
{
  public class FieLog
  {
    public string txType { get; set; }
    public string txMess { get; set; }

    public FieLog()
    {
    }

    public FieLog(FiMeta fimType, string txMess)
    {
      this.txType = fimType.ftTxKey; //txType;
      this.txMess = txMess;
    }
  }
}