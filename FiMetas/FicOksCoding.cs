using OrakUtilDotNetCore.FiCollections;
using OrakUtilDotNetCore.FiDataContainer;
using OrakUtilDotNetCore.FiOrm;

namespace OrakUtilDotNetCore.FiMetas;

// Csharp FiCol Class Generation v1
public static class FicOksCoding //: IFiTableMeta
{

  public static FicList GetTableCols()
  {
    FicList ficList = new FicList();

    ficList.Add(OkTableName());
    ficList.Add(OkTableFields());
    ficList.Add(OkCsvFields());


    return ficList;
  }

  public static FicList GetTableColsTrans()
  {
    FicList ficList = new FicList();



    return ficList;
  }

  public static FiCol OkTableName()
  {
    FiCol fiCol = new FiCol("okTableName");

    return fiCol;
  }

  public static FiCol OkTxWhere()
  {
    FiCol fiCol = new FiCol("okTxWhere");
    return fiCol;
  }

  public static FiCol OkTableFields()
  {
    FiCol fiCol = new FiCol("okTableFields");

    return fiCol;
  }

  public static FiCol OkCsvFields()
  {
    FiCol fiCol = new FiCol("okCsvFields");

    return fiCol;
  }



}