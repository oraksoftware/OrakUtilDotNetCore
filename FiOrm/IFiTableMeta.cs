using OrakUtilDotNetCore.FiCollections;

namespace OrakUtilDotNetCore.FiOrm
{


  public interface IFiTableMeta
  {
    string GetITxTableName();

    string GetITxPrefix();

    FicList GenITableCols();

    FicList GenITableColsTrans();
  }

}