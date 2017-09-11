using System;
using System.Web;
using System.Drawing;

namespace HandlersModules
{
    public class ImageHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            using (var bmap = new Bitmap(context.Request.PhysicalPath))
            {
                using (var gphx = Graphics.FromImage(bmap))
                {
                    var fnt = new Font("Verdana", 10, FontStyle.Italic);
                    var frmt = new StringFormat();
                    frmt.Alignment = StringAlignment.Center;
                    frmt.LineAlignment = StringAlignment.Center;

                    gphx.DrawString("ASP.NET Programming", fnt, Brushes.White, new Rectangle(120, 70, 300, 20), frmt);
                }
                context.Response.ContentType = "image/jpeg";
                bmap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
        }

        #endregion
    }
}
