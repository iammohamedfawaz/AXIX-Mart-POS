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
    public partial class DailySales : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string solduser;
        public DailySales()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadCashier();
        }

        public void LoadCashier()
        {
            cbCashier.Items.Clear();
            cbCashier.Items.Add("All Cashier");
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tbUserAccount WHERE role LIKE 'Cashier'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cbCashier.Items.Add(dr["username"].ToString());
            }
            dr.Close();
            cn.Close();
        }

       

        public void LoadSold()
        {
            int i = 0;
            double total = 0;
            dgvDailySales.Rows.Clear();
            cn.Open();
            if(cbCashier.Text=="All Cashier")
            {
                cm = new SqlCommand("Select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tbCart as c inner join tbProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dtFrom.Value + "'  and '" + dtTo.Value + "'", cn);
            }
            else
            {
                cm = new SqlCommand("Select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tbCart as c inner join tbProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dtFrom.Value + "'  and '" + dtTo.Value + "' and cashier like '" + cbCashier.Text + "'", cn);
            }
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                total += double.Parse(dr["total"].ToString());
                dgvDailySales.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
            }
            dr.Close();
            cn.Close();
            lblTotal.Text = total.ToString("#,##0.00");
        }

        private void CbCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void DtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void DtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void DailySales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void DgvDailySales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvDailySales.Columns[e.ColumnIndex].Name;
            if (colName == "Cancel")
            {
                CancelOrder cancelOrder = new CancelOrder(this);
                cancelOrder.txtId.Text = dgvDailySales.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancelOrder.txtTransNo.Text = dgvDailySales.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancelOrder.txtPcode.Text = dgvDailySales.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancelOrder.txtDescription.Text = dgvDailySales.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancelOrder.txtPrice.Text = dgvDailySales.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancelOrder.txtQty.Text = dgvDailySales.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancelOrder.txtDiscount.Text = dgvDailySales.Rows[e.RowIndex].Cells[7].Value.ToString();
                cancelOrder.txtTotal.Text = dgvDailySales.Rows[e.RowIndex].Cells[8].Value.ToString();
                cancelOrder.txtCancelledBy.Text = solduser;
                cancelOrder.ShowDialog();

            }
        }
    }
}
