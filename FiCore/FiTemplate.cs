namespace OrakUtilDotNetCore.FiCore
{
  using System.Collections.Generic;
  using System.Text.RegularExpressions;

  public class FiTemplate
  {
    //public string txValue { get; set; }

    public static string ReplaceTemplateParams(string input, Dictionary<string, object>? @params)
    {
      if (string.IsNullOrEmpty(input) || @params == null || @params.Count == 0)
        return input;

      return Regex.Replace(input, @"\{\{(.*?)\}\}", match =>
      {
        string key = match.Groups[1].Value.Trim();
        return (@params.ContainsKey(key) ? @params[key]?.ToString() : match.Value) ?? ""; // Eğer key varsa değiştir, yoksa olduğu gibi bırak.
      });
    }
  }

}