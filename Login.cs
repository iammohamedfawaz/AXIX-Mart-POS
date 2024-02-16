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
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        public string _pass = "";
        public bool _isactivate;
        public Login()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            txtUsername.Focus();
        }

        private void Username_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username") {
                txtUsername.Text = "";

                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void Username_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";

                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";

                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";

                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string _username = "", _name = "", _role = "";
            try
            {
                bool found;
                cn.Open();
                cm = new SqlCommand("Select * From tbUserAccount Where username = @username and password = @password", cn);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);
                cm.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _username = dr["username"].ToString();
                    _name = dr["name"].ToString();
                    _role = dr["role"].ToString();
                    _pass = dr["password"].ToString();
                    _isactivate = bool.Parse(dr["isactivate"].ToString());

                }
                else
                {
                    found = false;
                }
                dr.Close();
                cn.Close();

                if (found)
                {
                    if (!_isactivate)
                    {
                        MessageBox.Show("Account is deactivate .Unable to login", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Compare passwords with case-insensitivity
                    if (string.Compare(txtPassword.Text, _pass, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (_role == "Cashier")
                        {
                            MessageBox.Show("Welcome " + _name + "|", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Clear();
                            txtPassword.Clear();
                            this.Hide();
                            Cashier cashier = new Cashier();
                            cashier.lblUsername.Text = _username;
                            cashier.lblName.Text = _name + "|" + _role;
                            cashier.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Welcome " + _name + "|", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Clear();
                            txtPassword.Clear();
                            this.Hide();
                            MainForm main = new MainForm();
                            main.lblUsername.Text = _username;
                            main.lblName.Text = _name;
                            main._pass = _pass;
                            main.ShowDialog();
                        }
                    }
                    else
                    {
                     //   MessageBox.Show("Invalid username and password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);//
                    }
                }
                else
                {
                //    MessageBox.Show("Invalid username and password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);//
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnLogin.PerformClick();
        }
    }
}
