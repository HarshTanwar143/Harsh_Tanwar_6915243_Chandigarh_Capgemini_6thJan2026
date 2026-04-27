namespace EmployeeManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            cmbDepartment = new ComboBox();
            lblDepartment = new Label();
            txtSalary = new MaskedTextBox();
            lblSalary = new Label();
            txtEmail = new MaskedTextBox();
            lblEmail = new Label();
            txtName = new TextBox();
            txtID = new TextBox();
            lblName = new Label();
            lblID = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            btnSearch = new Button();
            groupBox2 = new GroupBox();
            txtSearch = new TextBox();
            lblKeyword = new Label();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbDepartment);
            groupBox1.Controls.Add(lblDepartment);
            groupBox1.Controls.Add(txtSalary);
            groupBox1.Controls.Add(lblSalary);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(lblID);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(747, 199);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Employee Details";
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(128, 166);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(592, 23);
            cmbDepartment.TabIndex = 9;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(23, 166);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(70, 15);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "Department";
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(128, 132);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(592, 23);
            txtSalary.TabIndex = 7;
            txtSalary.MaskInputRejected += txtSalary_MaskInputRejected;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Location = new Point(55, 135);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(38, 15);
            lblSalary.TabIndex = 6;
            lblSalary.Text = "Salary";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(128, 95);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(592, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(54, 103);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(128, 65);
            txtName.Name = "txtName";
            txtName.Size = new Size(592, 23);
            txtName.TabIndex = 3;
            // 
            // txtID
            // 
            txtID.Location = new Point(129, 34);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(592, 23);
            txtID.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(54, 68);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(20, 34);
            lblID.Name = "lblID";
            lblID.Size = new Size(73, 15);
            lblID.TabIndex = 0;
            lblID.Text = "Employee ID";
            lblID.Click += lblID_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(108, 230);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(189, 230);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(270, 230);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 13;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(645, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSearch);
            groupBox2.Controls.Add(lblKeyword);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Location = new Point(12, 272);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(747, 62);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(128, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(511, 23);
            txtSearch.TabIndex = 17;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(37, 26);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(53, 15);
            lblKeyword.TabIndex = 16;
            lblKeyword.Text = "Keyword";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 340);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(747, 98);
            dataGridView1.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnLoad);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management System";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtID;
        private Label lblName;
        private Label lblID;
        private TextBox txtName;
        private MaskedTextBox txtEmail;
        private Label lblEmail;
        private MaskedTextBox txtSalary;
        private Label lblSalary;
        private Button btnSearch;
        private Button btnLoad;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private ComboBox cmbDepartment;
        private Label lblDepartment;
        private GroupBox groupBox2;
        private TextBox txtSearch;
        private Label lblKeyword;
        private DataGridView dataGridView1;
    }
}
