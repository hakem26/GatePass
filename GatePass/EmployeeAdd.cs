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
    public partial class EmployeeAdd : Form
    {
        DatabaseOperation operation = new DatabaseOperation();
        string query;
        DataSet ds;
        public EmployeeAdd()
        {
            InitializeComponent();
        }

        private void AddEmployeeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameTB.Text;
                string username = usernameTB.Text;
                string password = passTB.Text;
                string contact = contactTB.Text;
                string address = addressTB.Text;
                string gender = genderCB.Text;
                string city = cityTB.Text;
                string state = stateTB.Text;
                string hireDate = hireDateDTP.Text;
                if (!String.IsNullOrEmpty(name) &&
                    !String.IsNullOrEmpty(username) &&
                    !String.IsNullOrEmpty(password) &&
                    !String.IsNullOrEmpty(contact) &&
                    !String.IsNullOrEmpty(address) &&
                    !String.IsNullOrEmpty(gender) &&
                    !String.IsNullOrEmpty(city) &&
                    !String.IsNullOrEmpty(state) &&
                    !String.IsNullOrEmpty(hireDate))
                {
                    Int64 contactInt = Int64.Parse(contact);
                    query = "select * from appUser where username = '" + username + "' and uenabled = 1";
                    ds = operation.GetData(query);
                    if (ds.Tables[0].Rows.Count == 0 && ds != null)
                    {
                        query = "insert into appUser(username,upass,urole) values('"+username +"', '"+password +"', 'EMPLOYEE'";
                        operation.SetData(query, null);
                    }
                    else
                    {
                        MessageBox.Show("username allready exist. try a different username!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Fill all inputs", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethings were wrong: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contactTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyNumber(e);
        }
    }
}
