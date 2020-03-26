using System.Configuration;

namespace CVControl.Application
{
    public static class Config
    {
        public static string LogPath => ConfigurationManager.AppSettings["LogPath"];
    }
}