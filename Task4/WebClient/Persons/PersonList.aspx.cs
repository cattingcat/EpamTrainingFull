using DataAccessors.Accessors;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class PersonList : System.Web.UI.Page
    {
        private IAccessor<Person> accessor;
        
        #region lifecycle
        protected void Page_Init(object sender, EventArgs e)
        {
            Global.GlobalLogger.Trace("PersonList init");
            accessor = Global.PersonAccessor;            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.GlobalLogger.Trace("PersonList load");
            try
            {
                string personId = Request["delete"];
                if (!string.IsNullOrEmpty(personId))
                {
                    accessor.DeleteById(int.Parse(personId));
                }
            }
            catch (SqlException ex)
            {
                Global.GlobalLogger.Warn("Person list load throw SQL exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
        }
        protected void InsertClick(object sender, EventArgs e)
        {
            Global.GlobalLogger.Trace("PersonList event: InsetrClick");
            try
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
            catch (SqlException ex)
            {
                Global.GlobalLogger.Warn("Person list load throw SQL exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");                
            }
            catch (FormatException ex)
            {
                Global.GlobalLogger.Warn("Person list load throw format exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Global.GlobalLogger.Trace("PersonList pre-render");
            try
            {
                IEnumerable<Person> persons = accessor.GetAll();
                FillTable(persons);
            }
            catch (SqlException ex)
            {
                Global.GlobalLogger.Warn("Person list load throw SQL exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
        }
        #endregion

        #region helpers
        private void FillTable(IEnumerable<Person> persons)
        {
            foreach (Person p in persons)
            {
                PersonRowControl c = LoadControl(@".\PersonRowControl.ascx") as PersonRowControl;
                c.Item = p;
                tableBody.Controls.Add(c);
            }
        }
        #endregion
    }
}