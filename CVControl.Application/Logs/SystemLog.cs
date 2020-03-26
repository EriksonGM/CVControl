using System;
using System.IO;

namespace CVControl.Application.Logs
{
    public static class SystemLog
    {
        private static readonly string _filePath;

        static SystemLog()
        {
            var data = DateTime.Now;

            var logPath = Config.LogPath;

            var logFolder = !string.IsNullOrWhiteSpace(logPath) ? logPath : $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\Logs";

            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            _filePath = $"{logFolder}\\{data:yyyy_MM_dd}.log";
        }

        public static void Erro(Exception ex)
        {
            try
            {
                var log = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} | Erro |\n" +
                          $"--> Source: {ex.Source}\n " +
                          $"--> Message: {ex.Message}\n " +
                          $"--> HelpLink: {ex.HelpLink}\n " +
                          $"--> StackTrace: {ex.StackTrace}\n " +
                          $"--> TargetSite: {ex.TargetSite}\n\n";

                System.IO.File.AppendAllText(_filePath, log);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void Info(string text)
        {
            try
            {
                var log = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} | Info | --> {text}\n";

                System.IO.File.AppendAllText(_filePath, log);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

}