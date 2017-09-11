using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandlersModulesMVC
{
    /// <summary>
    /// Summary description for CSVHandler
    /// </summary>
    public class CSVHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int n;
            if (int.TryParse(context.Request.QueryString["n"],out n))
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        context.Response.Write(j);
                        if (j < i)
                            context.Response.Write(',');
                    }
                    context.Response.Write(Environment.NewLine);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}