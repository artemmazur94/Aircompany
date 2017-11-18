using System;
using System.Globalization;
using System.IO;
using System.Web.Mvc;

namespace Aircompany.Web.Helpers
{
    public class HandleLogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            LogExcection(filterContext);
            base.OnException(filterContext);
        }

        private void LogExcection(ExceptionContext exceptionContext)
        {
            string path = "~/Logs/" + DateTime.Today.ToString("yy-MM-dd") + ".txt";
            var fullPath = exceptionContext.HttpContext.Server.MapPath(path);
            if (!File.Exists(fullPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                File.Create(fullPath).Close();
            }
            using (StreamWriter streamWriter = File.AppendText(fullPath))
            {
                streamWriter.WriteLine("\r\nLog entry:");
                streamWriter.WriteLine(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                if (exceptionContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    streamWriter.WriteLine("\nProfile id: " + IdentityManager.GetProfileIdFromAuthCookie(exceptionContext.HttpContext));
                }
                streamWriter.WriteLine("\nException type: " + exceptionContext.Exception.GetType());
                streamWriter.WriteLine("\nException message: " + exceptionContext.Exception.Message);
                streamWriter.WriteLine("\nStrack trace: \n" + exceptionContext.Exception.StackTrace);
                streamWriter.WriteLine("============================================================================================================");
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
        
    }
}