namespace HovLibrary.Transaksi
{
    partial class AllBorrowingFrm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitlec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returndateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(44, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(819, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(549, 64);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(287, 22);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(506, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "and";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(196, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(287, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Borrow Date (between)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(196, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(640, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Borrow Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(409, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "All Borrowing";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.MemberColumn,
            this.BookTitlec,
            this.BookCodeColumn,
            this.borrowdateDataGridViewTextBoxColumn,
            this.returndateDataGridViewTextBoxColumn,
            this.fineDataGridViewTextBoxColumn,
            this.ReturnColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(44, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(868, 200);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(HovLibrary.Borrowing);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MemberColumn
            // 
            this.MemberColumn.HeaderText = "Member Name";
            this.MemberColumn.MinimumWidth = 6;
            this.MemberColumn.Name = "MemberColumn";
            this.MemberColumn.ReadOnly = true;
            // 
            // BookTitlec
            // 
            this.BookTitlec.HeaderText = "Book Title";
            this.BookTitlec.MinimumWidth = 6;
            this.BookTitlec.Name = "BookTitlec";
            this.BookTitlec.ReadOnly = true;
            // 
            // BookCodeColumn
            // 
            this.BookCodeColumn.HeaderText = "Book Code";
            this.BookCodeColumn.MinimumWidth = 6;
            this.BookCodeColumn.Name = "BookCodeColumn";
            this.BookCodeColumn.ReadOnly = true;
            // 
            // borrowdateDataGridViewTextBoxColumn
            // 
            this.borrowdateDataGridViewTextBoxColumn.DataPropertyName = "borrow_date";
            this.borrowdateDataGridViewTextBoxColumn.HeaderText = "Borrow Date";
            this.borrowdateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.borrowdateDataGridViewTextBoxColumn.Name = "borrowdateDataGridViewTextBoxColumn";
            this.borrowdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // returndateDataGridViewTextBoxColumn
            // 
            this.returndateDataGridViewTextBoxColumn.DataPropertyName = "return_date";
            this.returndateDataGridViewTextBoxColumn.HeaderText = "Return Date";
            this.returndateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.returndateDataGridViewTextBoxColumn.Name = "returndateDataGridViewTextBoxColumn";
            this.returndateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fineDataGridViewTextBoxColumn
            // 
            this.fineDataGridViewTextBoxColumn.DataPropertyName = "fine";
            this.fineDataGridViewTextBoxColumn.HeaderText = "Fine";
            this.fineDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fineDataGridViewTextBoxColumn.Name = "fineDataGridViewTextBoxColumn";
            this.fineDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ReturnColumn
            // 
            this.ReturnColumn.HeaderText = "";
            this.ReturnColumn.MinimumWidth = 6;
            this.ReturnColumn.Name = "ReturnColumn";
            this.ReturnColumn.ReadOnly = true;
            this.ReturnColumn.Text = "Return";
            this.ReturnColumn.UseColumnTextForButtonValue = true;
            // 
            // AllBorrowingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AllBorrowingFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form - Borrowing";
            this.Load += new System.EventHandler(this.AllBorrowingFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitlec;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returndateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ReturnColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}