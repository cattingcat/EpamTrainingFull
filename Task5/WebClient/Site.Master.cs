using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private Stopwatch sw = new Stopwatch();

        protected void Page_Load(object sender, EventArgs e)
        {
            sw.Start();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            sw.Stop();
            elapsedTime.InnerText = "elapsed time: " + sw.ElapsedMilliseconds + "ms.";
        }
    }
}