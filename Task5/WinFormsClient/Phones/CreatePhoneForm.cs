using DataAccessors.Accessors;
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

namespace WinFormsClient.Phones
{
    public partial class CreatePhoneForm : Form
    {
        public Phone Result { get; set; }
        private IAccessor<Person> _personAccessor;

        public CreatePhoneForm(IAccessor<Person> personAccessor)
        {
            _personAccessor = personAccessor;
            InitializeComponent();
        }

        private void CreatePhoneForm_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var p in _personAccessor.GetAll())
                {
                    comboBox1.Items.Add(p);
                }
            }            
            catch (SqlException ex)
            {
                MessageBox.Show(this, "Database error",
                    "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTextBox.Text);
                string number = numberTextBox.Text.Trim();
                int ownerId = ((Person)comboBox1.SelectedItem).Id;

                Phone p = new Phone { Id = id, Number = number, PersonId = ownerId };
                Result = p;
            }
            catch (FormatException excp)
            {
                MessageBox.Show(this, "Please enter valid Id", "Invalid id", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = System.Windows.Forms.DialogResult.Abort;
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
