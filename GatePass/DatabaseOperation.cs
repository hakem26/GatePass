using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePass
{
    internal class DatabaseOperation
    {
        protected SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-HAMED\\TEW_SQLEXPRESS;Initial Catalog=GatePass;Integrated Security=True";
            return con;
        }
        public DataSet GetData(string query)
        {
            DataSet ds= new DataSet();
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection= con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption in get data: " + ex);
            }
            return ds;
        }
        public void SetData(string query, string msg)
        {
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                if (msg != null)
                    MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
