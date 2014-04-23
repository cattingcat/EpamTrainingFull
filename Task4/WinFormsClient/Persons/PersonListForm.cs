using DataAccessors.Accessors;
using DataAccessors.Data;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.Phones;

namespace WinFormsClient
{
    public partial class PersonListForm : Form
    {
        private IAccessor<Person> accessor = Program.PersonAccessor;

        public PersonListForm()
        {
            InitializeComponent();       
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        

        private void SetData(ICollection<Person> collection)
        {
            dataGridView1.Rows.Clear();
            foreach (Person p in collection)
            {
                dataGridView1.Rows.Add(p.Id, p.Name, p.LastName, p.DayOfBirth);
            }
        }
       
        private void ReloadData()
        {
            ICollection<Person> coll = null;
            try
            {
                coll = accessor.GetAll();
            }
            catch (SqlException e)
            {
                MessageBox.Show(this, "Database cant perform operation", 
                    "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetData(coll);
        }

        #region event handlers
        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (col == 4) // delete button
            {
                int personId = (int)dataGridView1.Rows[row].Cells[0].Value;

                try
                {
                    accessor.DeleteById(personId);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, "Database cant perform operation",
                        "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (col == 5) // show phone list button
            {
                int personId = (int)dataGridView1.Rows[row].Cells[0].Value;
                Form f = new PhoneListForm(personId);
                f.ShowDialog();
            }

            ReloadData();
        }

        private void insertPerson_Click(object sender, EventArgs e)
        {
            CreatePersonForm form = new CreatePersonForm();
            DialogResult res = form.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    accessor.Insert(form.Result);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, "Database cant perform operation",
                        "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ReloadData();
            }
        }

        private void insertPhone_Click(object sender, EventArgs e)
        {
            CreatePhoneForm form = new CreatePhoneForm();
            DialogResult res = form.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Program.PhoneAccessor.Insert(form.Result);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, "Database cant perform operation",
                        "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void phoneWindowCall(object sender, EventArgs e)
        {
            PhoneListForm plf = new PhoneListForm();
            plf.Show();
        }
        #endregion
    }
}
