namespace WinFormsClient
{
    partial class PersonListForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.phonesColBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertPersonToolStripMenuItem,
            this.insertPhoneToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // insertPersonToolStripMenuItem
            // 
            this.insertPersonToolStripMenuItem.Name = "insertPersonToolStripMenuItem";
            this.insertPersonToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.insertPersonToolStripMenuItem.Text = "InsertPerson";
            this.insertPersonToolStripMenuItem.Click += new System.EventHandler(this.insertPerson_Click);
            // 
            // insertPhoneToolStripMenuItem
            // 
            this.insertPhoneToolStripMenuItem.Name = "insertPhoneToolStripMenuItem";
            this.insertPhoneToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.insertPhoneToolStripMenuItem.Text = "InsertPhone";
            this.insertPhoneToolStripMenuItem.Click += new System.EventHandler(this.insertPhone_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameCol,
            this.LastName,
            this.DoB,
            this.DelColumn,
            this.phonesColBtn});
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 458);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MaxInputLength = 30;
            this.Id.Name = "Id";
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Name";
            this.NameCol.MaxInputLength = 30;
            this.NameCol.Name = "NameCol";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "LastName";
            this.LastName.MaxInputLength = 30;
            this.LastName.Name = "LastName";
            // 
            // DoB
            // 
            this.DoB.HeaderText = "DoB";
            this.DoB.MaxInputLength = 30;
            this.DoB.Name = "DoB";
            // 
            // DelColumn
            // 
            this.DelColumn.HeaderText = "Del";
            this.DelColumn.Name = "DelColumn";
            this.DelColumn.Text = "delete";
            this.DelColumn.Width = 30;
            // 
            // phonesColBtn
            // 
            this.phonesColBtn.HeaderText = "Phones";
            this.phonesColBtn.Name = "phonesColBtn";
            this.phonesColBtn.Width = 60;
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phoneWindowToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // phoneWindowToolStripMenuItem
            // 
            this.phoneWindowToolStripMenuItem.Name = "phoneWindowToolStripMenuItem";
            this.phoneWindowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.phoneWindowToolStripMenuItem.Text = "Phone window";
            this.phoneWindowToolStripMenuItem.Click += new System.EventHandler(this.phoneWindowCall);
            // 
            // PersonListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 497);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PersonListForm";
            this.Text = "Windows forms client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertPersonToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoB;
        private System.Windows.Forms.DataGridViewButtonColumn DelColumn;
        private System.Windows.Forms.DataGridViewButtonColumn phonesColBtn;
        private System.Windows.Forms.ToolStripMenuItem insertPhoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneWindowToolStripMenuItem;
    }
}

