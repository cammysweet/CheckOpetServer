using System;
using System.Configuration;
using System.IO;

namespace CheckOpetServer
{
    public class WriteLog
    {
        private static string pathLog = (ConfigurationManager.AppSettings["logPath"]);

        public static void SalvaLog(string result)
        {
            using (StreamWriter sw = File.AppendText(pathLog))
            {
                sw.WriteLine("Login efetuado com sucesso? '" + result + "' " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            }
        }
    }
}
