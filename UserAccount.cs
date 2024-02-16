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
    public partial class UserAccount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        MainForm main;
        public string username;
        string name;
        string role;
        string accstatus;
        public UserAccount(MainForm mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            main = mn;
            LoadUserAccount();
        }

        public void LoadUserAccount()
        {
            int i = 0;
            dgvUserAccount.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUserAccount", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUserAccount.Rows.Add(i, dr[0].ToString(), dr[3].ToString(), dr[4].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void Clear()
        {
            txtName.Clear();
            txtPasswordCreate.Clear();
            txtReTypePasswordCreate.Clear();
            txtUsernameCreate.Clear();
            cbRole.Text = "";
            txtUsernameCreate.Focus();
        }

        private void BtnSaveCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPasswordCreate.Text != txtReTypePasswordCreate.Text)
                {
                    MessageBox.Show("Password did not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cn.Open();
                cm = new SqlCommand("Insert into tbUserAccount(username, password, role, name) Values (@username, @password, @role, @name)", cn);
                cm.Parameters.AddWithValue("@username", txtUsernameCreate.Text);
                cm.Parameters.AddWithValue("@password", txtPasswordCreate.Text);
                cm.Parameters.AddWithValue("@role", cbRole.Text);
                cm.Parameters.AddWithValue("@name", txtName.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New account has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }

        }

        private void BtnCancelCreateAccount_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnSaveChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPasswordCurrentPassword.Text != main._pass)
                {
                    MessageBox.Show("Current password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(txtNewPasswordChange.Text != txtReTypePasswordChange.Text)
                {
                    MessageBox.Show("Confirm  new password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dbcon.ExecuteQuery("UPDATE tbUserAccount SET password= '" + txtNewPasswordChange.Text + "' WHERE username='" + lblUsername.Text + "'");
                MessageBox.Show("Password has been successfully changed", "Changed Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = main.lblUsername.Text;
        }

        private void BtnCancelChangePassword_Click(object sender, EventArgs e)
        {
            txtPasswordCurrentPassword.Clear();
            txtNewPasswordChange.Clear();
            txtReTypePasswordChange.Clear();
        }

        private void DgvUserAccount_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvUserAccount.CurrentRow.Index;
            username = dgvUserAccount[1, i].Value.ToString();
            name = dgvUserAccount[2, i].Value.ToString();
            role = dgvUserAccount[4, i].Value.ToString();
            accstatus = dgvUserAccount[3, i].Value.ToString();
            if (lblUsername.Text == username)
            {
                btnRemove.Enabled = false;
                btnResetPassword.Enabled = false;
                lblAccountNote.Text = "TO change the password, go to change password tag.";
            }
            else
            {
                btnRemove.Enabled = true;
                btnResetPassword.Enabled = true;
                lblAccountNote.Text = "To change the password for " + username + ", click Reset Password.";
            }
            groupBoxUser.Text = "Password for :" + username;         
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("You chose to remove this account from this Point Of Sales System User from the list.\n\n Are you sure you want to remove '" +username+ "' \\ '" + role + "'", "User Account", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dbcon.ExecuteQuery("DELETE FROM tbUserAccount WHERE username ='" + username + "'");
                MessageBox.Show("Account has been successfully deleted");
                LoadUserAccount();
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPassword reset = new ResetPassword(this);
            reset.ShowDialog();
        }

        private void BtnProperties_Click(object sender, EventArgs e)
        {
            UserProperties properties = new UserProperties(this);
            properties.txtFullName.Text = name + "\\"+ username +" Properties";
            properties.cbRole.Text = role;
            properties.cbActivate.Text = accstatus;
            properties.username = username;
            properties.ShowDialog();
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";

                txtSearch.ForeColor = Color.White;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";

                txtSearch.ForeColor = Color.White;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUserAccount();
        }
    }
}
