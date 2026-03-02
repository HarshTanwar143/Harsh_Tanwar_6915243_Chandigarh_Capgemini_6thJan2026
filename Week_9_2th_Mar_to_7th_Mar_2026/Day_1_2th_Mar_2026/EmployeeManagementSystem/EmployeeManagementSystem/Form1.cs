using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-CT4MMTD\\SQLEXPRESS01;Initial Catalog=CompanyDB;TrustServerCertificate=True;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadEmployees();
        }

        
        void LoadDepartments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT DepartmentID, DepartmentName FROM Departments", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDepartment.DataSource = dt;
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
            }
        }

       
        void LoadEmployees()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("GetEmployees", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        
#nullable disable
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtID.Text = row.Cells["EmployeeID"].Value != null ? row.Cells["EmployeeID"].Value.ToString() : "";
            txtName.Text = row.Cells["Name"].Value != null ? row.Cells["Name"].Value.ToString() : "";
            txtEmail.Text = row.Cells["Email"].Value != null ? row.Cells["Email"].Value.ToString() : "";
            txtSalary.Text = row.Cells["Salary"].Value != null ? row.Cells["Salary"].Value.ToString() : "";

            // Match department in ComboBox by name
            string deptName = row.Cells["DepartmentName"].Value != null
                ? row.Cells["DepartmentName"].Value.ToString()
                : "";

            foreach (DataRowView item in cmbDepartment.Items)
            {
                if (item["DepartmentName"].ToString() == deptName)
                {
                    cmbDepartment.SelectedItem = item;
                    break;
                }
            }
        }
#nullable restore

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadEmployees();
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SearchEmployee", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Keyword", txtSearch.Text.Trim());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            txtID.Text = ""; txtName.Text = ""; txtEmail.Text = ""; txtSalary.Text = "";
        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please click a row in the table to select an employee first.",
                    "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(txtID.Text));
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@DepartmentID", cmbDepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text.Trim()));
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Employee updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadEmployees();
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please click a row in the table to select an employee first.",
                    "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete: {txtName.Text}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(txtID.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Employee deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadEmployees();
            }
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                MessageBox.Show("Please fill in Name, Email, and Salary.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@DepartmentID", cmbDepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text.Trim()));
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Employee added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadEmployees();
        }

      
        private void btnLoad_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadEmployees();
        }


        void ClearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
            txtSearch.Text = "";
            if (cmbDepartment.Items.Count > 0)
                cmbDepartment.SelectedIndex = 0;
        }

        private void lblID_Click(object sender, EventArgs e) { }
        private void txtSalary_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
    }
}