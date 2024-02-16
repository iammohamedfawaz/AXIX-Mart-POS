using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_POS_AXIX_MART
{
    public partial class UserProperties : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
       
        UserAccount account;
        public string username;
        public UserProperties(UserAccount user)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            account = user;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TxtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to change this account properties?", "Change Properties", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tbUserAccount SET name=@name, role=@role, isactivate=@isactivate WHERE username='" + username + "'", cn);
                    cm.Parameters.AddWithValue("@name", txtFullName.Text);
                    cm.Parameters.AddWithValue(@"role", cbRole.Text);
                    cm.Parameters.AddWithValue("@isactivate", cbActivate.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Account properties has been successfully changed!", "Update Properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    account.LoadUserAccount();
                    this.Dispose();
                }
                
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
