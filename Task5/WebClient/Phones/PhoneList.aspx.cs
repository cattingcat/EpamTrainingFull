using DataAccessors.Accessors;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebClient.Phones
{
    public partial class PhoneList : System.Web.UI.Page
    {
        private IAccessor<Phone> _phoneAccessor;
        private IAccessor<Person> _personAccessor;

        public PhoneList() { }
        public PhoneList(IAccessor<Phone> phoneAccessor, IAccessor<Person> personAccessor)
        {
            _personAccessor = personAccessor;
            _phoneAccessor = phoneAccessor;
        }

        #region lifecycle
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.GlobalLogger.Trace("phone page load");
            try
            {               
                string phoneId = Request["delete"];
                if (!string.IsNullOrEmpty(phoneId))
                {
                    _phoneAccessor.DeleteById(int.Parse(phoneId));
                }
            }
            catch (SqlException ex)
            {
                Global.GlobalLogger.Warn("phone page throw SQL Exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
            catch (FormatException ex)
            {
                Global.GlobalLogger.Warn("phone page throw format Exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
        }

        protected void InsertClick(object sender, EventArgs e)
        {
            Global.GlobalLogger.Trace("phone page event: insertClick");
            try
            {
                Phone p = new Phone
                {
                    Id = int.Parse(idInput.Value),
                    Number = numInput.Value,
                    PersonId = int.Parse(personSelector.Value)
                };
                _phoneAccessor.Insert(p);
            }
            catch (SqlException ex)
            {
                Global.GlobalLogger.Warn("phone page throw SQL Exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");

            }
            catch (FormatException ex)
            {
                Global.GlobalLogger.Warn("phone page throw format Exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Global.GlobalLogger.Trace("phone page rpe render");
            try
            {
                IEnumerable<Phone> phones = _phoneAccessor.GetAll();

                string param = Request.QueryString["ownerId"];
                int ownerId;
                bool b = int.TryParse(param, out ownerId);
                if (b)
                {
                    phones = from p in phones where p.PersonId == ownerId select p;
                }

                FillTable(phones);
                FillPersonSelector(_personAccessor.GetAll(), b ? new Nullable<int>(ownerId) : null);
            }
            catch (SqlException ex)
            {
                Global.GlobalLogger.Warn("phone page throw SQL Exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
            catch (FormatException ex)
            {
                Global.GlobalLogger.Warn("phone page throw format Exception: {0}", ex.Message);
                Session.Add("exception", ex);
                Server.Transfer("/ErrorPage.aspx");
            }
        }
        #endregion

        #region helpers
        private void FillTable(IEnumerable<Phone> phones)
        {
            foreach (Phone p in phones)
            {
                PhoneTableRow c = LoadControl(@".\PhoneTableRow.ascx") as PhoneTableRow;
                c.Item = p;
                tableBody.Controls.Add(c);
            }
        }
        private void FillPersonSelector(IEnumerable<Person> persons, int? ownerId)
        {
            personSelector.Items.Clear();
            foreach (Person p in persons)
            {
                personSelector.Items.Add(new ListItem()
                {
                    Text = p.LastName + ' ' + p.Name,
                    Value = p.Id.ToString(),
                    Selected = (p.Id == ownerId)
                });
            }
        }
        #endregion
    }
}