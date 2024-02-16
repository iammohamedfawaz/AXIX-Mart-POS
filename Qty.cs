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
   
    public partial class Qty : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Point Of Sales";
        private string pcode;
        private double price; 
        private String transno;
        private int qty;
        Cashier cashier;
        public Qty(Cashier cash)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cashier = cash;

        }

        private void Qt_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void ProductDetails(string pcode, double price, string transno, int qty)
        {
            this.pcode = pcode;
            this.price = price;
            this.transno = transno;
            this.qty = qty;
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (txtQty.Text != string.Empty))
            {
                try
                {
                    string id = "";
                    int cart_qty = 0;
                    bool found = false;

                    using (SqlConnection cn = new SqlConnection(dbcon.myConnection()))
                    {
                        cn.Open();
                        using (SqlCommand cm = new SqlCommand("Select * from tbCart Where transno = @transno and pcode = @pcode", cn))
                        {
                            cm.Parameters.AddWithValue("@transno", transno);
                            cm.Parameters.AddWithValue("@pcode", pcode);
                            using (SqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();
                                    id = dr["id"].ToString();
                                    cart_qty = int.Parse(dr["qty"].ToString());
                                    found = true;
                                }
                                else
                                {
                                    found = false;
                                }
                            }
                        }

                        if (found)
                        {
                            if (qty < (int.Parse(txtQty.Text) + cart_qty))
                            {
                                MessageBox.Show("Unable to proceed. Remaining qty on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            using (SqlCommand cm = new SqlCommand("Update tbCart set qty = (qty + " + int.Parse(txtQty.Text) + ")Where id= '" + id + "'", cn))
                            {
                                cm.ExecuteNonQuery();
                            }

                            cashier.txtBarcode.Clear();
                            cashier.txtBarcode.Focus();
                            cashier.LoadCart();
                            this.Dispose();
                        }
                        else
                        {
                            if (qty < (int.Parse(txtQty.Text) + cart_qty))
                            {
                                MessageBox.Show("Unable to proceed. Remaining qty on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            using (SqlCommand cm = new SqlCommand("INSERT INTO tbCart(transno, pcode, price, qty, sdate, cashier)VALUES(@transno, @pcode, @price, @qty, @sdate, @cashier)", cn))
                            {
                                cm.Parameters.AddWithValue("@transno", transno);
                                cm.Parameters.AddWithValue("@pcode", pcode);
                                cm.Parameters.AddWithValue("@price", price);
                                cm.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                                cm.Parameters.AddWithValue("@sdate", DateTime.Now);
                                cm.Parameters.AddWithValue("@cashier", cashier.lblUsername.Text);
                                cm.ExecuteNonQuery();
                            }

                            cashier.txtBarcode.Clear();
                            cashier.txtBarcode.Focus();
                            cashier.LoadCart();
                            this.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, stitle);
                }
            }
        }

    }
}



