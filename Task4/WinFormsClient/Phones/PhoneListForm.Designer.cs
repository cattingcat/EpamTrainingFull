namespace WinFormsClient.Phones
{
    partial class PhoneListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.phoneIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletePhoneCol = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phoneIdCol,
            this.phoneNumberCol,
            this.deletePhoneCol});
            this.dataGridView1.Location = new System.Drawing.Point(2, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(483, 391);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellClick);
            // 
            // phoneIdCol
            // 
            this.phoneIdCol.HeaderText = "Id";
            this.phoneIdCol.Name = "phoneIdCol";
            // 
            // phoneNumberCol
            // 
            this.phoneNumberCol.HeaderText = "Number";
            this.phoneNumberCol.Name = "phoneNumberCol";
            // 
            // deletePhoneCol
            // 
            this.deletePhoneCol.HeaderText = "Del";
            this.deletePhoneCol.Name = "deletePhoneCol";
            // 
            // PhoneListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 408);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PhoneListForm";
            this.Text = "PhoneListForm";
            this.Load += new System.EventHandler(this.PhoneListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberCol;
        private System.Windows.Forms.DataGridViewButtonColumn deletePhoneCol;
    }
}