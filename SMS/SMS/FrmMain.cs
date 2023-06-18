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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudent fm = new FrmStudent();
            fm.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e) 
        {
            if (Gc.role != "Admin")
            {
                adminToolStripMenuItem.Visible = true;
            }

            toolStripStatusLabel1.Text = "User:" + Gc.Username;
            toolStripStatusLabel2.Text = "Role:" + Gc.role;
            toolStripStatusLabel3.Text = "Date:" + DateTime.Now.ToLongDateString();

        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin fl = new FrmLogin();
            fl.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
