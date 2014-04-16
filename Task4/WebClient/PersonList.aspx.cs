using DataAccessors.Accessors;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class PersonList1 : System.Web.UI.Page
    {
        private IAccessor<Person> accessor;
        private Stopwatch sw = new Stopwatch();

        protected void Page_Init(object sender, EventArgs e)
        {
            sw.Start();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string key = accessorSelector.SelectedValue;
            accessor = Global.Accessors[key];

            string personId = Request["delete"];
            if (!string.IsNullOrEmpty(personId))
            {
                accessor.DeleteById(int.Parse(personId));
            }
        }

        protected void InsertClick(object sender, EventArgs e)
        {
            Person p = new Person
            {
                Id = int.Parse(idInput.Value),
                Name = nameInput.Value.Trim(),
                LastName = lastNameInput.Value.Trim(),
                DayOfBirth = DateTime.Parse(dateInput.Value)
            };
            accessor.Insert(p);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            foreach (Person p in accessor.GetAll())
            {
                PersonRowControl c = LoadControl(@".\PersonRowControl.ascx") as PersonRowControl;
                c.Item = p;
                tableBody.Controls.Add(c);               
            }
            sw.Stop();
            elapsedTime.InnerText = "elapsed time: " + sw.ElapsedMilliseconds + "ms.";
        }
    }
}