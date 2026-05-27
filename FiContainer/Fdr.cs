using OrakUtilDotNetCore.FiCollections;
using OrakUtilDotNetCore.FiCore;
using OrakUtilDotNetCore.FiMetas;
using System.Data;

namespace OrakUtilDotNetCore.FiContainer;

public class Fdr
{
  //private bool? _boResult;

  public bool? fdBoResult { get; set; }

  /**
   * boExecution false olursa, sorgunun server vs bağlantı kurulamadığını gösterir.
   *
   * fdBoResult,boExecution yapıldığı için bazı yerlerde mantık hatası var
   *
   * Kullanılmamaya çalışılmalı
   *
   */
  //public bool? boExecution { get; set; }

  public bool? boTknValid { get; set; }

  // private object _refValue;
  public object refValue { get; set; }

  public string txErrorMsgShort { get; set; }
  public string txErrorMsgDetail { get; set; }
  public int lnRowsAffected { get; set; }

  public int? lnIdAffected { get; set; }

  // public int? fqpLnTotal { get; set; }
  public object spec1 { get; set; }

  public int? lnStatusCode { get; set; }

  public string txId { get; set; }

  public string txMessage { get; set; }

  public Exception refException { get; set; }

  public string txResponse { get; set; }

  //public string txResponse2 { get; set; }

  private string fdTxVal { get; set; }

  /**
   * İşlem Dönüşü Fkb Değeri
   */
  public Fkb fdFkbVal { get; set; }

  private FkbList fdFkbListVal { get; set; }

  // Json dönüşümünde ignore etmek için kullanılır
  //[System.Text.Json.Serialization.JsonIgnore]
  /**
   * İşlem Dönüşü DataTable değeri
   */
  public DataTable fdDtbVal { get; set; }







  public List<FieLog> listFieLog { get; set; }

  /**
   * External Object
   */
  public void SetExtObject<TS>(TS value)
  {
    this.spec1 = value;
  }

  public TS GetExtObject<TS>()
  {
    return (TS)this.spec1;
  }

  // XIMSNIP ifnull yapısı
  public List<FieLog> GetListFieLogInit()
  {
    return listFieLog ??= new List<FieLog>();
  }

  /**
* İşlem sonuçlarının hepsi true olursa sonuç true olur, bir tane false varsa sonuç false olur.
*
* Tüm İşlemlerde Birleştirilen Alanlar : Log, Message, Exception
*
* Value ile birleştirme vs yapmaz.
*
* @param fdrSubWork Birleştirilecek Fdr (alt fdr işi)
*/
  public void CombineAndByBoExec(Fdr fdrSubWork)
  {

    // And işlemi olduğu false sonuç, boExecution false yapar
    if (FiBool.IsFalse(fdrSubWork.fdBoResult))
    {
      fdBoResult = false;
      //setLnFailureOpCount(getLnFailureOpCountInit() + 1);
    }

    if (FiBool.IsTrue(fdrSubWork.fdBoResult))
    {
      //setLnSuccessOpCount(getLnSuccessOpCountInit() + 1);
      fdBoResult ??= true;
    }

    // null sonuçlara özel combine işlemi
//        if (fdrSubWork.getBoResult() == null) {
//
//        }

    // if(FiBool.isTrue(getBoMultiFdr())){
    //   getFdrListInit().add(fdrSubWork);
    // }

    // Tümü için yapılacaklar
    if (fdrSubWork.refException != null)
    {
      refException ??= fdrSubWork.refException;
      // exception birden fazla olma ihtimali var.
      //getListExceptionInit().add(fdrSubWork.getException());
    }

    // Tüm işlemlerde mesaj birleştirilir.
    if (!FiString.IsEmpty(fdrSubWork.txMessage)) AppendMessageLn(fdrSubWork.txMessage);

    // Loglar birleştirilir.
    //if (!FiCollection.isEmpty(fdrSubWork.getLogList())) getLogListInit().addAll(fdrSubWork.getLogList());

    // appendRowsAffected(fdrSubWork.getRowsAffectedOrEmpty());
    // appendLnUpdated(fdrSubWork.getLnUpdatedRows());
    // appendLnInserted(fdrSubWork.getLnInsertedRows());
    // appendLnDeleted(fdrSubWork.getLnDeletedRows());

    // Birleştirme yapıldığı için eski Fdr'ye log eklenmesi engellenir
    // fdrSubWork.setBoLockAddLog(true);
  }

  public void CombineAnd(Fdr fdrSub)
  {

    // And işlemi olduğu false sonuç, boExecution false yapar
    if (FiBool.IsFalse(fdrSub.fdBoResult))
    {
      fdBoResult = false;
      //setLnFailureOpCount(getLnFailureOpCountInit() + 1);
    }

    if (FiBool.IsTrue(fdrSub.fdBoResult))
    {
      //setLnSuccessOpCount(getLnSuccessOpCountInit() + 1);
      fdBoResult ??= true;
    }

    // null olduğunda fdBoResult sonucunu değiştirme
//        if (fdrSubWork.getBoResult() == null) {
//
//        }

    // if(FiBool.isTrue(getBoMultiFdr())){
    //   getFdrListInit().add(fdrSubWork);
    // }

    // Tüm işlemlerde mesaj birleştirilir.
    // Loglar birleştirilir.
    CombineLogsAndMess(fdrSub);

    // Tümü için yapılacaklar
    if (fdrSub.refException != null)
    {
      refException ??= fdrSub.refException;
      // exception birden fazla olma ihtimali var.
      //getListExceptionInit().add(fdrSubWork.getException());
    }

    // appendRowsAffected(fdrSubWork.getRowsAffectedOrEmpty());
    // appendLnUpdated(fdrSubWork.getLnUpdatedRows());
    // appendLnInserted(fdrSubWork.getLnInsertedRows());
    // appendLnDeleted(fdrSubWork.getLnDeletedRows());

    // Birleştirme yapıldığı için eski Fdr'ye log eklenmesi engellenir
    // fdrSubWork.setBoLockAddLog(true);
  }

//     public void CombineAnd2(IFdr fdrSub)
//     {
//
//       // And işlemi olduğu false sonuç, boExecution false yapar
//       if (FiBool.IsFalse(fdrSub.fdBoResult))
//       {
//         fdBoResult = false;
//         //setLnFailureOpCount(getLnFailureOpCountInit() + 1);
//       }
//
//       if (FiBool.IsTrue(fdrSub.fdBoResult))
//       {
//         //setLnSuccessOpCount(getLnSuccessOpCountInit() + 1);
//         fdBoResult ??= true;
//       }
//
//       // null olduğunda fdBoResult sonucunu değiştirme
// //        if (fdrSubWork.getBoResult() == null) {
// //
// //        }
//
//       // if(FiBool.isTrue(getBoMultiFdr())){
//       //   getFdrListInit().add(fdrSubWork);
//       // }
//
//       // Tüm işlemlerde mesaj birleştirilir.
//       // Loglar birleştirilir.
//       CombineLogsAndMess(fdrSub);
//
//       // Tümü için yapılacaklar
//       if (fdrSub.refException != null)
//       {
//         refException ??= fdrSub.refException;
//         // exception birden fazla olma ihtimali var.
//         //getListExceptionInit().add(fdrSubWork.getException());
//       }
//
//       // appendRowsAffected(fdrSubWork.getRowsAffectedOrEmpty());
//       // appendLnUpdated(fdrSubWork.getLnUpdatedRows());
//       // appendLnInserted(fdrSubWork.getLnInsertedRows());
//       // appendLnDeleted(fdrSubWork.getLnDeletedRows());
//
//       // Birleştirme yapıldığı için eski Fdr'ye log eklenmesi engellenir
//       // fdrSubWork.setBoLockAddLog(true);
//     }

  public void AppendMessageLn(string txValue)
  {
    txMessage = txMessage + (!FiString.IsEmpty(txMessage) ? "\n" : "") + txValue;
  }

  public void AppendMessageWithSc(string txValue)
  {
    txMessage = txMessage + (!FiString.IsEmpty(txMessage) ? ";;" : "") + txValue;
  }

  public Fdr(bool fdBoResult) { this.fdBoResult = fdBoResult; }

  public Fdr(int prmLnRowsAffected)
  {
    this.lnRowsAffected = prmLnRowsAffected;

    if (prmLnRowsAffected > 0)
    {
      this.fdBoResult = true;
    }
    else
    {
      this.fdBoResult = false;
    }

  }

  public Fdr() {}

  public static Fdr FactoryScopeId(int prmIdAffected)
  {
    var fiReturn = new Fdr();
    fiReturn.lnIdAffected = prmIdAffected;
    fiReturn.lnRowsAffected = prmIdAffected;

    if (prmIdAffected > 0)
    {
      fiReturn.fdBoResult = true;
    }
    else
    {
      fiReturn.fdBoResult = false;
    }

    return fiReturn;
  }

  public static Fdr BuiObject(object returnObject)
  {
    var fiReturn = new Fdr();
    fiReturn.refValue = returnObject;
    return fiReturn;
  }

  // public void ExceptionQueryErrorLog(Exception exception)
  // {
  //   this.txErrorMsgShort = exception.Message;
  //   this.txErrorMsgDetail = FiLogWeb.getStackTrace(exception);
  //   this.lnRowsAffected = -1;
  //   this.blResult = false;
  //   this.boExecution = false;
  // }

  public bool IsTrueBoResult()
  {
    if (this.fdBoResult == null) return false;
    return fdBoResult.Value;
  }

  // public bool IsTrueBoExec()
  // {
  //   if (this.boExecution == null) return false;
  //   return boExecution.Value;
  //   ;
  // }

  public Fdr BuiMess(string txMessage)
  {
    this.txMessage = txMessage;
    return this;
  }

  public void CombineLogsAndMess(Fdr fdrSubWork)
  {
    // Tüm işlemlerde mesaj birleştirilir.
    if (!FiString.IsEmpty(fdrSubWork.txMessage)) AppendMessageLn(fdrSubWork.txMessage);

    // Loglar Birleştirilir
    GetListFieLogInit().AddRange(fdrSubWork.GetListFieLogInit());
  }

  public void AddLogInfo(string txMess)
  {
    GetListFieLogInit().Add(new FieLog(FimLogTypes.Info(), txMess));

  }

  public void AddLogError(string txMess)
  {
    GetListFieLogInit().Add(new FieLog(FimLogTypes.Error(), txMess));
  }

  public void SetBoExecAndResultFalse()
  {
    //this.boExecution = false;
    this.fdBoResult = false;
  }

  public void SetBoExecAndResultTrue()
  {
    //this.boExecution = true;
    this.fdBoResult = true;
  }

  public Fkb GetFdFkbValInit()
  {
    return fdFkbVal ??= new Fkb();
  }


}