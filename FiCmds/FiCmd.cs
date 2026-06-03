using OrakUtilDotNetCore.FiContainer;
using OrakUtilDotNetCore.FiMetas;
using System.Diagnostics;
using Serilog;

namespace OrakUtilDotNetCore.FiCmds
{
  public static class FiCmd
  {

    // static FiCmd()
    // {
    //   Log.Logger = new LoggerConfiguration()
    //     .MinimumLevel.Debug()
    //     .WriteTo.Console()
    //     .CreateLogger();
    // }

    public static Fdr RunCommandOnAppBase(string txCommand, string txArguments)
    {
      Log.Information($"RunCommandOnAppBase {txCommand} {txArguments}");

      Fdr fdrMain = new Fdr();
      Fkb fkb = new Fkb();
      fdrMain.fdFkbVal = fkb;

      //ObmFile.CheckCreateUserFolder();
      //string txTimeStamp = FiDate.TxTimeStampForFile();
      //string arguments = $@"{txArguments}:";

      // rclone.exe'nin bulunduğu dizini belirle
      string commandWitPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, txCommand);

      // if (!System.IO.File.Exists(rcloneExePath))
      // {
      //   ilogger.LogError($"rclone.exe bulunamadı: {rcloneExePath}");
      //   return;
      // }

      ProcessStartInfo processInfo = new ProcessStartInfo
      {
        FileName = commandWitPath,
        Arguments = txArguments,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true,
        WorkingDirectory = Path.GetDirectoryName(commandWitPath)
      };

      using Process? process = Process.Start(processInfo);

      if (process == null)
      {
        fdrMain.txMessage = "process null";
        fdrMain.fdBoResult = false;
        return fdrMain;
      }

      string outputStand = process.StandardOutput.ReadToEnd();
      Log.Information($"process output: {outputStand}");

      string outputError = process.StandardError.ReadToEnd();
      Log.Information($"process error output: {outputError}");
      //fdrMain.txMessage += outputError.Trim();

      if (string.IsNullOrWhiteSpace(outputError))
      {
        //Log.Warning($"process error output: {outputError}");
        outputError = "";
      }

      // Sadece gerçek hata mesajlarını göster
      if (outputError.Contains("ERROR") || outputError.Contains("FATAL"))
      {
        //Console.WriteLine("Hata Çıktısı:" + txErr);
        fkb.AddFim(FimFiCmd.F1TxOutErr(), outputError.Trim());
        fdrMain.fdBoResult = false;
      }
      else
      {
        // Bilgilendirme/Notice Çıktısı
        outputStand += "\n" + outputError.Trim();
        fkb.AddFim(FimFiCmd.F1TxOutSt(), outputStand.Trim());
        fdrMain.fdBoResult = true;
      }

      process.WaitForExit();
      int exitCode = process.ExitCode;

      // exitCode == 0 ise komut başarıyla tamamlanmış demektir
      // , ancak bazı durumlarda hata mesajları çıkabilir.
      // Bu nedenle, exitCode'ye ek olarak error output'u da kontrol etmek önemlidir.

      return fdrMain;
    }
  }
}