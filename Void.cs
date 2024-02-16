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
    public partial class Void : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        CancelOrder cancelOrder;
        public Void(CancelOrder cancel)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            txtUsername.Focus();
            cancelOrder = cancel;

        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";

                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";

                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";

                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";

                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == cancelOrder.txtCancelledBy.Text)
                {
                    MessageBox.Show("Void by name and cancelled by name are same!. Please void by another person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                string user;
                cn.Open();
                cm = new SqlCommand("Select * FROM tbUserAccount Where username = @username and password = @password", cn);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);
                cm.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    user = dr["username"].ToString();
                    dr.Close();
                    cn.Close();
                    SaveCancelOrder(user);

                    if(cancelOrder.cbAddInventory.Text=="yes")
                    {
                        dbcon.ExecuteQuery("UPDATE tbProduct SET qty = qty + " + cancelOrder.numericDownCancelQty.Value + " where pcode= '" + cancelOrder.txtPcode.Text + "'"); 
                    }
                    dbcon.ExecuteQuery("UPDATE tbCart SET qty = qty + " + cancelOrder.numericDownCancelQty.Value + " where id LIKE '" + cancelOrder.txtId.Text + "'");
                    MessageBox.Show("Order transaction sucessfully cancelled!", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    cancelOrder.ReloadSoldList();
                    cancelOrder.Dispose();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SaveCancelOrder(string user)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("INSERT INTO tbCancel (transno, pcode, price, qty, total, sdate, voidby, cancelledby, reason, action) VALUES (@transno, @pcode, @price, @qty, @total, @sdate, @voidby, @cancelledby, @reason, @action)", cn);
                cm.Parameters.AddWithValue("@transno", cancelOrder.txtTransNo.Text);
                cm.Parameters.AddWithValue("@pcode", cancelOrder.txtPcode.Text);
                cm.Parameters.AddWithValue("@price", double.Parse(cancelOrder.txtPrice.Text));
                cm.Parameters.AddWithValue("@qty", int.Parse(cancelOrder.txtQty.Text));
                cm.Parameters.AddWithValue("@total", double.Parse(cancelOrder.txtTotal.Text));
                cm.Parameters.AddWithValue("@sdate", DateTime.Now);
                cm.Parameters.AddWithValue("@voidby", user);
                cm.Parameters.AddWithValue("@cancelledby", cancelOrder.txtCancelledBy.Text);
                cm.Parameters.AddWithValue("@reason", cancelOrder.txtReasons.Text);
                cm.Parameters.AddWithValue("@action", cancelOrder.cbAddInventory.Text);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
