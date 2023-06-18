using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMS.Utils;
using SMS.Bll;
using SMS.Dao;
using System.Data.SqlClient;

namespace SMS
{
    public partial class FrmStudent : Form
    {


        public FrmStudent()
        {
            InitializeComponent();
            LoadData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
                Student s = new Student();
                s.Name = txtName.Text;
                s.Address = txtAddress.Text;
                s.Course = cmbCourse.Text;
                s.Fees = Convert.ToInt32(txtFees.Text);
                StudentDao sd= new StudentDao();
                sd.SaveStudent(s);
                MessageBox.Show("Record Saved!", "SMS");
                LoadData();
                ClearData();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "SMS");
            }
            
        }
        private void LoadData()
        {
            try
            {
                StudentDao sd = new StudentDao();
                DataTable dt = sd.GetAllStudents();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SMS");
            }
        }

        private void ClearData() 
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            cmbCourse.SelectedIndex = 0;
            txtFees.Text = "0";
            txtName.Focus();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            LoadData();
            cmbCourse.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Gc.SID = Convert.ToInt16(dataGridView1.Rows[i].Cells["SID"].Value);
            txtName.Text = dataGridView1.Rows[i].Cells["Name"].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[i].Cells["Address"].Value.ToString();
            cmbCourse.Text = dataGridView1.Rows[i].Cells["Course"].Value.ToString();
            txtFees.Text = dataGridView1.Rows[i].Cells["Fees"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try 
            {
                Student s = new Student();
                s.SID = Gc.SID;
                s.Name = txtName.Text;
                s.Address = txtAddress.Text;
                s.Course = cmbCourse.Text;
                s.Fees = Convert.ToInt32(txtFees.Text);
                StudentDao sd = new StudentDao();
                sd.UpdateStudent(s);
                MessageBox.Show("Record Updated!", "SMS");
                LoadData();
                ClearData();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "SMS");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Do You Want To Delete!?", "SMS",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Student s = new Student();
                    StudentDao sd = new StudentDao();
                    sd.DeleteStudent(Gc.SID);
                    MessageBox.Show("Record Deleted!", "SMS");
                    LoadData();
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SMS");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
