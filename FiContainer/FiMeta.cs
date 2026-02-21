namespace OrakUtilDotNetCore.FiDataContainer
{
  public class FiMeta
  {
    /**
     * TxCode (TxKodu)
    */
    public string ftTxKey { get; set; }

    public string ftTxValue { get; set; }

    /**
     * LnCode (LnKodu)
     * <p>
     * Key Meta Karşılık Gelen Integer Kod varsa
     */
    public int ftLnKey { get; set; }

    /**
     * Açıklama (Description) gibi düşünebiliriz
     */
    public string ftTxLabel { get; set; }

    public string txType { get; set; }

    public FiMeta() {}

    public FiMeta(string ftTxKey)
    {
      this.ftTxKey = ftTxKey;
    }


    public static FiMeta BuiLn(int ftLnKey)
    {
      return new FiMeta() { ftLnKey = ftLnKey };
    }
    public static FiMeta BuiLnAndKey(int lnKey, string txKey)
    {
      return new FiMeta() { ftLnKey = lnKey, ftTxKey = txKey };
    }
  }

}