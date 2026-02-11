using OrakUtilDotNetCore.FiCollections;
using OrakUtilDotNetCore.FiCore;

namespace OrakUtilDotNetCore.FiDataContainer
{
  public class FiCol
  {
    public string fcTxFieldName { get; set; }

    /**
     * Veritabanında farklı bir alan ismi varsa, dbField'a yazılır
     */
    public string fcTxDbField { get; set; }
    public string fcTxHeader { get; set; }

    /**
     * Farklı sistemdeki ismi (xml alanındaki)
     */
    public string fcTxRefField { get; set; }

    public string fcTxFieldType { get; set; }

    // /**
    //  * Alanın Veri Türü (FiColType dan alınabilir)
    //  */
    // public string ofcTxColType { get; set; }

    public bool? fcBoTransient { get; set; }

    public bool? fcBoNullable { get; set; }

    public string fcTxFieldDesc { get; set; }

    public int? fcLnLength { get; set; }
    public int? fcLnPrecision { get; set; }
    public int? fcLnScale { get; set; }

    public string fcTxIdType { get; set; }

    public bool boInsertCol { get; set; }

    /**
     * Sorguda güncellenmesi gereken alan olduğunu belirtir, aksi listedeki tüm sütunlara güncellenecek alan olarak düşünür
     */
    public bool boUpdateCol { get; set; }

    /**
     * Primary Key olduğunu gösterir
     */
    public bool fcBoPrimaryKey { get; set; }

    //public FiWpfCntx refWpfCntx { get; set; }

    /**
     * Alanın alacağı şablon, xml için düşünüldü.
     */
    public string ficTxTemplate { get; set; }

    // /**
    //  * Alanın varsayılan veri türü
    //  *
    //  */
    //public FiColType fiColType { get; set; }

    public string fcTxCompType { get; set; }

    public FimList fcRefFimList { get; set; }

    public FiCol(string fcTxFieldName)
    {
      this.fcTxFieldName = fcTxFieldName;
    }

    public FiCol(string fcTxFieldName, string fcTxHeader)
    {
      this.fcTxFieldName = fcTxFieldName;
      this.fcTxHeader = fcTxHeader;
    }

    public string GetFieldName()
    {
      return this.fcTxFieldName;
    }

    public FiCol()
    {
    }

    public override string ToString()
    {
      return this.fcTxFieldName ?? "";
    }

    // public FiCol BuiColType(FiColType fiColType)
    // {
    //   this.fiColType = fiColType;
    //   return this;
    // }

    public string GetOfcTxDbFieldOr()
    {
      return FiString.IsEmpty(fcTxDbField) ? fcTxFieldName : fcTxDbField;
    }

    // ReSharper disable once InconsistentNaming
    public string tof()
    {
      return fcTxFieldName;
    }
    public bool CheckFiColIfPrimaryKey()
    {
      return !FiString.IsEmpty(this.fcTxIdType);
    }

    public bool CheckFiColIfIdentityPrimaryKey()
    {
      if (FiString.IsEmpty(this.fcTxIdType))
      {
        return false;
      }

      return this.fcTxIdType == "identity";
    }

    public string GetTxDbFieldOrTxFieldName()
    {
      return !FiString.IsEmpty(fcTxDbField) ? fcTxDbField : fcTxFieldName;
    }

    // ReSharper disable once InconsistentNaming
    public string fnm()
    {
      return this.fcTxFieldName;
    }

    public string fnmTemplate()
    {
      return "{{" + this.fcTxFieldName + "}}";
    }

    public bool IsText()
    {
      if (this.fcTxFieldType == null) return false;

      if (this.fcTxFieldType.ToLower().Equals("text")
        || this.fcTxFieldType.IndexOf("nvarchar", StringComparison.OrdinalIgnoreCase) != -1
      )
      {
        return true;
      }
      return false;
    }
    public bool IsBool()
    {
      if (this.fcTxFieldType == null) return false;

      if (this.fcTxFieldType.ToLower().Equals("bool"))
      {
        return true;
      }
      return false;
    }
  } // end class
}