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

    public static Fdr runCommand(string txCommand, string txArguments)
    {
      Log.Information($"run {txCommand} {txArguments}");

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

      using Process process = Process.Start(processInfo);

      if (process == null)
      {
        fdrMain.txMessage = "process null";
        fdrMain.fdBoResult = false;
        return fdrMain;
      }

      string output = process.StandardOutput.ReadToEnd();
      fkb.AddFim(FimFiCmd.F1TxOutSt(), output.Trim());
      Log.Information($"process output: {output}");

      string outputError = process.StandardError.ReadToEnd();
      //fdrMain.txMessage += outputError.Trim();
      fkb.AddFim(FimFiCmd.F1TxOutErr(), output.Trim());
      Log.Information($"process error output: {outputError}");

      process.WaitForExit();
      return fdrMain;
    }
  }
}