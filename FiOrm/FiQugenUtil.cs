using OrakUtilDotNetCore.FiContainer;

namespace OrakUtilDotNetCore.FiOrm
{
  /// <summary>
  /// Query generation utility methods used by FiQuGenMs and related classes.
  /// </summary>
  public static class FiQugenUtil
  {
    /// <summary>
    /// Creates the "fieldName = @fieldName AND " template.
    /// </summary>
    public static string FormSqlAssignAnd(string fcTxFieldName)
    {
      return fcTxFieldName + " = @" + fcTxFieldName + GetTxAnd();
    }

    /// <summary>
    /// Creates the "fieldName IN ( @fieldName ) AND " template.
    /// </summary>
    public static string FormSqlAssignIn(string fcTxFieldName)
    {
      return fcTxFieldName + " IN ( @" + fcTxFieldName + " ) " + GetTxAnd();
    }

    public static string FormSqlAssignAndByFic(FiCol fiCol)
    {
      return FormSqlAssignAnd(fiCol.fcTxFieldName);
    }

    /// <summary>
    /// Creates the "fieldName IN ( @fieldName ) AND " template.
    /// </summary>
    public static string FormSqlAssignInByFic(FiCol fiCol)
    {
      return FormSqlAssignIn(fiCol.fcTxFieldName);
    }

    /// <summary>
    /// Creates the "fieldName = @fieldName, " template, using the database
    /// field name when one is configured.
    /// </summary>
    public static string FormSqlAssignVarAndCommaByFic(FiCol fiCol)
    {
      string fieldName = string.IsNullOrWhiteSpace(fiCol.fcTxDbField)
        ? fiCol.fcTxFieldName
        : fiCol.fcTxDbField;
      return FormSqlAssignVarAndComma(fieldName);
    }

    /// <summary>
    /// Creates the "fieldName = @fieldName, " template.
    /// </summary>
    public static string FormSqlAssignVarAndComma(string fcTxFieldName)
    {
      return fcTxFieldName + "= @" + fcTxFieldName + GetTxComma();
    }

    /// <summary>
    /// Creates the "@varName, " template.
    /// </summary>
    public static string FormSqlVarComma(string fcTxFieldName)
    {
      return "@" + fcTxFieldName + GetTxComma();
    }

    /// <summary>
    /// Creates the "@varName, " template.
    /// </summary>
    public static string FormSqlVarCommaByFic(FiCol fiCol)
    {
      return FormSqlVarComma(fiCol.fcTxFieldName);
    }

    public static string FormSqlFieldComma(string fcTxFieldName)
    {
      return fcTxFieldName + GetTxComma();
    }

    public static string FormSqlFieldCommaByFic(FiCol fiCol)
    {
      return FormSqlFieldComma(fiCol.fcTxFieldName);
    }

    public static string GetTxComma()
    {
      return ", ";
    }

    public static string GetTxAnd()
    {
      return " AND ";
    }
  }
}
