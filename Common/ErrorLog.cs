using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ErrorLog
    {
        public static void LogError(Exception ex) {
            string message = $"Time :{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}";
            message += Environment.NewLine;
            message += "----------------------------------------------------------------";
            message += Environment.NewLine;
            message += $"Message : {ex.Message}";
            message += Environment.NewLine;
            message += $"StackTrace : {ex.StackTrace}";
            message += Environment.NewLine;
            message += $"Source : {ex.Source}";
            message += Environment.NewLine;
            message += $"TargetSite : {ex.TargetSite.ToString()}";
            message += Environment.NewLine;
            message += "----------------------------------------------------------------";
            message += Environment.NewLine;

            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/ErrorLog.txt");


            using (StreamWriter writer = File.AppendText(path)) {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
