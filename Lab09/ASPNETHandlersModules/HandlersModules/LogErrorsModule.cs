using System;
using System.Web;
using System.IO;

namespace HandlersModules
{
    public class LogErrorsModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide
            // custom logging implementation for it
            context.LogRequest += new EventHandler(OnLogRequest);
            context.Error += new EventHandler(OnAppError);
        }

        public void OnAppError(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            foreach (var ex in app.Context.AllErrors)
            {
                File.WriteAllText(Path.Combine(@"C:\UCSD\ASP.NET MVC\Labs\Lab09\ASPNETHandlersModules\HandlersModulesMVC\Log", Path.GetRandomFileName()) + ".txt", ex.ToString());
            }
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }
    }
}
