namespace OrakUtilDotNetCore.FiContainer
{
  public static class DtoFdr1
  {
    public static object GenFdr1(Fdr fdr)
    {
      dynamic obj = new System.Dynamic.ExpandoObject();

      //if (fdr.fdBoResult != null)
      //if (fdr.refValue != null)
      obj.boResult = fdr.fdBoResult;
      obj.refValue = fdr.refValue;

      //if (fdr.boExecution != null) obj.boExecution = fdr.boExecution;
      //if (fdr.fqpLnTotal != null) obj.fqpLnTotal = fdr.fqpLnTotal;
      if (fdr.txMessage != null) obj.txMessage = fdr.txMessage;
      if (fdr.txErrorMsgShort != null) obj.txErrorMsgShort = fdr.txErrorMsgShort;
      if (fdr.txResponse != null) obj.txResponse = fdr.txResponse;
      if (fdr.GetListFieLogInit().Count > 0) obj.listFieLog = fdr.GetListFieLogInit();
      if (fdr.fdDtbVal != null) obj.fdDtbVal = fdr.fdDtbVal;

      // geçici olarak eklendi
      //if (obj.refValue == null && fdr.obReturn != null) obj.refValue = fdr.obReturn;

      // var expando = (IDictionary<string, object>)obj;
      // if (!expando.ContainsKey("fdBoResult") || expando["fdBoResult"] == null) expando["fdBoResult"] = null;
      // if (!expando.ContainsKey("refValue") || expando["refValue"] == null) expando["refValue"] = null;

      return obj;
    }

    public static object GenFdr2(Fdr fdr)
    {
      dynamic obj = new System.Dynamic.ExpandoObject();

      //if (fdr.fdBoResult != null)
      //if (fdr.refValue != null)
      obj.boResult = fdr.fdBoResult;
      obj.refValue = fdr.refValue;

      //if (fdr.boExecution != null) obj.boExecution = fdr.boExecution;
      //if (fdr.fqpLnTotal != null) obj.fqpLnTotal = fdr.fqpLnTotal;
      if (fdr.txMessage != null) obj.txMessage = fdr.txMessage;
      if (fdr.txErrorMsgShort != null) obj.txErrorMsgShort = fdr.txErrorMsgShort;
      if (fdr.txResponse != null) obj.txResponse = fdr.txResponse;
      if (fdr.GetListFieLogInit().Count > 0) obj.listFieLog = fdr.GetListFieLogInit();
      if (fdr.fdDtbVal != null) obj.refDtbVal = fdr.fdDtbVal;

      // geçici olarak eklendi
      //if (obj.refValue == null && fdr.obReturn != null) obj.refValue = fdr.obReturn;

      // var expando = (IDictionary<string, object>)obj;
      // if (!expando.ContainsKey("fdBoResult") || expando["fdBoResult"] == null) expando["fdBoResult"] = null;
      // if (!expando.ContainsKey("refValue") || expando["refValue"] == null) expando["refValue"] = null;

      return obj;
    }

    /**
     * FiResponse için yapıldı
     */
    public static object GenFdr3(Fdr fdr)
    {
      dynamic obj = new System.Dynamic.ExpandoObject();

      // Kalıcı alanlar
      obj.boResult = fdr.fdBoResult;
      //obj.refValue = fdr.refValue;

      // Opsiyonel Alanlar
      //if (fdr.boExecution != null) obj.boExecution = fdr.boExecution;
      //if (fdr.fqpLnTotal != null) obj.fqpLnTotal = fdr.fqpLnTotal;
      if (fdr.txMessage != null) obj.txMessage = fdr.txMessage;
      if (fdr.refValue != null) obj.refValue = fdr.refValue;
      if (fdr.txErrorMsgShort != null) obj.txErrorMsgShort = fdr.txErrorMsgShort;
      if (fdr.txResponse != null) obj.txResponse = fdr.txResponse;
      if (fdr.GetListFieLogInit().Count > 0) obj.listFieLog = fdr.GetListFieLogInit();
      if (fdr.fdDtbVal != null) obj.refDtbVal = fdr.fdDtbVal;
      if (fdr.fdFkbListVal != null) obj.fdFkbListVal = fdr.fdFkbListVal;

      // geçici olarak eklendi
      //if (obj.refValue == null && fdr.obReturn != null) obj.refValue = fdr.obReturn;

      // var expando = (IDictionary<string, object>)obj;
      // if (!expando.ContainsKey("fdBoResult") || expando["fdBoResult"] == null) expando["fdBoResult"] = null;
      // if (!expando.ContainsKey("refValue") || expando["refValue"] == null) expando["refValue"] = null;

      return obj;
    }
    public static object GenFiRes(FiRes fiRes)
    {
      dynamic obj = new System.Dynamic.ExpandoObject();

      //if (fdr.fdBoResult != null)
      //if (fdr.refValue != null)
      obj.boResult = fiRes.fsBoResult;
      //obj.refValue = fiRes.fsRefValue;

      if (fiRes.fsTxMessage != null) obj.fsTxMessage = fiRes.fsTxMessage;
      if (fiRes.fsRefFdr != null)
      {
        obj.fsRefFdr = DtoFdr1.GenFdr3(fiRes.fsRefFdr);
      }


      return obj;
    }


  } // end class
}