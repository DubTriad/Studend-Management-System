using SMS.Bll;
using SMS.Dao;
using SMS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Equals("") || txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("Username and Password Required!", "SMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    User u = new User();
                    u.Username = txtUsername.Text;
                    u.Password = txtPassword.Text;
                    UserDao ud = new UserDao();
                    DataTable dt = ud.CheckUser(u);
                    if (dt.Rows.Count > 0)
                    {
                        Gc.Username = txtUsername.Text;
                        Gc.Password = txtPassword.Text;
                        Gc.role = dt.Rows[0]["Role"].ToString();
                        this.Hide();
                        FrmMain fm = new FrmMain();
                        fm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!", "SMS");
                    }
                    
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "SMS-Error");
            }
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
