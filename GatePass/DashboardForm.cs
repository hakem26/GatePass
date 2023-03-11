using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePass
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }
        string role;
        public DashboardForm(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            string backgroundName;
            if ("ADMIN".Equals(role))
            {
                employeeToolStrip.Visible = true;
                backgroundName = "gatePassBg1";
                welcomeText.Text = "Welcome Admin";
            }
            else
            {
                employeeToolStrip.Visible = false;
                backgroundName = "gatePassBg2";
                welcomeText.Text = "Welcome Employee";
            }
            Image image = Image.FromFile(Utility.GetImageStorePath(backgroundName));
            this.BackgroundImage = image;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<EmployeeAdd>().Count() == 1)
            {
                Application.OpenForms.OfType<EmployeeAdd>().First().BringToFront();
            }
            else
            {
                EmployeeAdd employeeAdd = new EmployeeAdd();
                employeeAdd.Show();
            }
        }
    }
}
