using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace WebClient
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Session["exception"] as Exception;
            if (ex is FormatException)
            {
                exceptionDescription.InnerText = "Invalid tnput";
            }
            else if (ex is SqlException)
            {
                exceptionDescription.InnerText = "Sorry, database problem";
            }
            Session.Remove("exception");            

            string[] imgSrc = Directory.EnumerateFiles(Server.MapPath(@"\content"), "*.jpg").ToArray();
            Random rnd = new Random();
            string filename = imgSrc[rnd.Next(imgSrc.Length - 2) + 1];            
            filename = Path.GetFileNameWithoutExtension(filename);             
            img.Src = String.Format("content/{0}.jpg", filename);

            if (!string.IsNullOrEmpty(RouteData.Values["img"] as string))
            {
                img.Src = String.Format("content/{0}.jpg", RouteData.Values["img"] as string);
            }
        }
    }
}