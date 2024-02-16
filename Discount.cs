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
    public partial class Discount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        Cashier cashier;
        string stitle = "Point Of Sales";
        public Discount(Cashier cash)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cashier = cash;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void TextDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double disc = double.Parse(txtTotalPrice.Text) * double.Parse(txtDiscount.Text) * 0.01;
                txtDiscountAmount.Text = disc.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                txtDiscountAmount.Text = "0.00";
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Add didcount? Click yes to confirm", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tbCart SET disc_percent=@disc_percent WHERE id = @id", cn);
                    cm.Parameters.AddWithValue("@disc_percent", double.Parse(txtDiscount.Text));
                    cm.Parameters.AddWithValue("@id", int.Parse(lblId.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    cashier.LoadCart();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle);
            }
        }
    }
}
