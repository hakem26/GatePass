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
    public partial class LoginForm : Form
    {
        DatabaseOperation operation = new DatabaseOperation();
        string query;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select * from appUser where username = '" + usernameTB.Text + "' and upass = '" + passwordTB.Text + "' and uenabled = 1";
                DataSet ds = operation.GetData(query);
                if (ds != null && ds.Tables[0].Rows.Count !=0) 
                {
                    string role = ds.Tables[0].Rows[0][3].ToString();
                    Int64 appUserPK = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    DashboardForm dashboardForm = new DashboardForm(role);
                    dashboardForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User not found!", "Informtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption in loginBtn click: " + ex);
                MessageBox.Show("Somethins\'s wrong: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
