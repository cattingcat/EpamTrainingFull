using DataAccessors.Accessors;
using DataAccessors.Data;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class MainFormc : Form
    {
        private IAccessor<Person> accessor;
        private string appConfigConnectionString = "CompactDB";

        public MainFormc()
        {
            InitializeComponent();
            accessor = new OrmPersonAccessor(appConfigConnectionString);           
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
        private IAccessor<Person> MakeAccessor(int id)
        {
            switch (id)
            {
                case 1:
                    return new OrmPersonAccessor(appConfigConnectionString);
                case 2:
                    return new ADOPersonAccessor(appConfigConnectionString);
                case 3:
                    return new DirectoryPersonAccessor(@"App_Data\FolderDBb");
                case 4:
                    return new FilePersonAccessor(@"App_Data\FilePersonDB.txt");
                case 5:
                    return new MemoryPersonAccessor();
            }
            return null;
        }
        private void ReloadData()
        {
            var coll = accessor.GetAll();
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
                accessor.DeleteById(personId);
            }

            ReloadData();
        }
        private void changeAccessorEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked)
                return;

            int resp = int.Parse(item.Tag.ToString());
            accessor = MakeAccessor(resp);

            ReloadData();

            foreach (ToolStripMenuItem i in accessorsToolStripMenuItem.DropDownItems)
            {
                i.Checked = false;
            }
            item.Checked = true;
        }
        #endregion

        private void insertPerson_Click(object sender, EventArgs e)
        {
            PersonForm form = new PersonForm();
            DialogResult res = form.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                accessor.Insert(form.Result);
                ReloadData();
            }
        }
    }
}
