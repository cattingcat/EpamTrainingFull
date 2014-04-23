using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.Phones
{
    public partial class PhoneTableRow : System.Web.UI.UserControl
    {

        public Phone Item { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}