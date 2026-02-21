using OrakUtilDotNetCore.FiCollections;
using OrakUtilDotNetCore.FiCore;
using OrakUtilDotNetCore.FiDataContainer;
using System.Globalization;

namespace OrakUtilDotNetCore.FiContainer;

public class FiKeytext : Dictionary<string, string>
{

  public HashSet<FiCol> setFiCol { get; set; }

  //public string txTemplate {get; set;}

  public FiKeytext()
  {
  }

  public FiKeytext(IDictionary<string, string> dictionary) : base(dictionary)
  {
  }

  public void AddFiCol(FiCol ficol, string objValue)
  {
    GetSetFiColInit().Add(ficol);
    Add(ficol.fcTxFieldName, objValue);
  }

  public void AddForceFiCol(FiCol ficol, string objValue)
  {
    if (ContainsKey(ficol.fcTxFieldName))
    {
      Remove(ficol.fcTxFieldName);
    }
    else
    {
      GetSetFiColInit().Add(ficol);
    }
    Add(ficol.fcTxFieldName, objValue);
  }

  public void AddFieldByFiCol(FiCol ficol, string objValue)
  {
    Add(ficol.fcTxFieldName, objValue);
  }

  public void AddFieldByFim(FiMeta fiMeta, string objValue)
  {
    Add(fiMeta.ftTxKey, objValue);
  }

  public void AddFieldBy(FiMeta fiMeta, string objValue)
  {
    Add(fiMeta.ftTxKey, objValue);
  }

  public void AddFieldBy(FiCol ficol, string objValue)
  {
    Add(ficol.fcTxFieldName, objValue);
  }

  /**
   * Default imple. Add Force (if exists, remove it, add)
   */
  public void AddField(FiCol fiCol, string objValue)
  {
    AddOverWrite(fiCol.fcTxFieldName, objValue);
  }

  public void AddOverWrite(string key, string objValue)
  {
    this[key] = objValue;
    // if (ContainsKey(key))
    // {
    //   Remove(key);
    // }
    // Add(key, objValue);
  }

  /**
   * Yoksa ekleme yapar, varsa birşey yapmaz
   */
  public void AddFieldIfNot(FiCol ficol, string objValue)
  {
    if (!ContainsKey(ficol.fcTxFieldName))
    {
      Add(ficol.fcTxFieldName, objValue);
    }
  }

  public HashSet<FiCol> GetSetFiColInit()
  {
    return setFiCol ??= new HashSet<FiCol>();
  }

  public bool ContainsKeyByFiCol(FiCol fiCol)
  {
    return ContainsKey(fiCol.fcTxFieldName);
  }

  public bool ContainsAnyKeyByFiCol(params FiCol[] fiCols)
  {
    return fiCols.Any(fiCol => ContainsKey(fiCol.fcTxFieldName));
  }

  public bool ContainsAllKeyByFiCol(params FiCol[] fiCols)
  {
    return fiCols.All(fiCol => ContainsKey(fiCol.fcTxFieldName));
  }

  // public void ConvertCsvToListString(string txKey)
  // {
  //   string txValue = GetAsString(txKey);
  //
  //   if (FiString.IsEmpty(txValue)) return;
  //
  //   List<string> listValues = txValue.Split(',').Select(item => item.Trim()).ToList();
  //   // Perform additional operations with listValues if needed
  //   Remove(txKey);
  //   Add(txKey, listValues);
  // }

  /**
   * Boolean ToString yaparken lower yapar (normalde csh True olarak yapıyor)
   */
  public string GetAsString(string txKey)
  {
    // Eğer sözlük belirtilen anahtarı içeriyorsa:
    if (this.ContainsKey(txKey))
    {
      // Değeri al ve string türüne çevir.
      object value = this[txKey];

      // if(value is bool)
      // {
      //   return value.ToString().ToLower();
      // }

      return value switch
      {
        // Double ise, InvariantCulture ile formatla
        double doubleValue => doubleValue.ToString(CultureInfo.InvariantCulture),
        int intValue => intValue.ToString(CultureInfo.InvariantCulture),
        _ => value?.ToString() ?? ""
      };

    }
    // Eğer anahtar bulunamazsa, null döner
    return null;
  }

  public string GetFieldAsString(FiCol fiCol)
  {
    return GetAsString(fiCol.fcTxFieldName);
  }

  public object GetFieldAsObject(FiCol fiCol)
  {
    return GetAsObject(fiCol.fcTxFieldName);
  }
  public object GetAsObject(string txKey)
  {
    // Eğer sözlük belirtilen anahtarı içeriyorsa:
    if (this.ContainsKey(txKey))
    {
      // Değeri al ve string türüne çevir.
      object value = this[txKey];
      return value;
    }
    // Eğer anahtar bulunamazsa, null döner
    return null;
  }
  public FkbList GetFieldAsFkbList(FiCol fiCol)
  {
    if (this.ContainsKey(fiCol.fcTxFieldName))
    {
      // Değeri al ve string türüne çevir.
      object value = this[fiCol.fcTxFieldName];

      if (value is FkbList fkbList)
      {
        return fkbList;
      }
    }
    // Eğer anahtar bulunamazsa, null döner
    return null;
  }

  public FkbList GetFieldAsFkbListNtn(FiCol fiCol)
  {
    return GetFieldAsFkbList(fiCol) ?? new FkbList();
  }
  public void RemoveField(FiCol fiCol)
  {
    Remove(fiCol.fcTxFieldName);
  }
  public bool? GetFieldAsBool(FiCol psrsBoSuccess)
  {
    // Eğer sözlük belirtilen anahtarı içeriyorsa:
    if (this.ContainsKey(psrsBoSuccess.fcTxFieldName))
    {
      // Değeri al ve string türüne çevir.
      object value = this[psrsBoSuccess.fcTxFieldName];
      ;

      if (value is bool boValue)
      {
        return boValue;
      }

      return null;
    }
    // Eğer anahtar bulunamazsa, null döner
    return null;
  }
  public double? GetFieldAsDouble(FiCol fiCol)
  {

    if (this.ContainsKey(fiCol.fcTxFieldName))
    {
      object value = this[fiCol.fcTxFieldName];

      if (value is double dbValue)
      {
        return dbValue;
      }

      return null;
    }
    // Eğer anahtar bulunamazsa, null döner
    return null;
  }


  public double GetFieldAsDoubleNtn(FiCol fiCol)
  {
    return GetFieldAsDouble(fiCol) ?? 0;
  }
}