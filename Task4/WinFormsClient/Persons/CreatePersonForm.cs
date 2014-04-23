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
    public partial class CreatePersonForm : Form
    {
        public Person Result { get; set; }

        public CreatePersonForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTextBox.Text);
                string name = nameTextBox.Text.Trim();
                string lastName = lastNameTextBox.Text.Trim();
                DateTime dt = dateTimePicker.Value;

                Person p = new Person { Id = id, Name = name, LastName = lastName, DayOfBirth = dt };
                Result = p;
            }
            catch (FormatException excp)
            {
                MessageBox.Show(this, "Please enter valid Id", "Invalid id", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = System.Windows.Forms.DialogResult.Abort;
                return;
            }
            catch (ArgumentOutOfRangeException excp)
            {
                MessageBox.Show(this, "Date id out of range, please try again", "Invalid date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = System.Windows.Forms.DialogResult.Abort;
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
