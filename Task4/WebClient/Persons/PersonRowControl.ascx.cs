using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class PersonRowControl : System.Web.UI.UserControl
    {
        public Person Item { get; set; }
    }
}