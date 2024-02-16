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
    public partial class Adjustments : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        MainForm main;
        int _qty;
        public Adjustments(MainForm mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            main = mn;
            ReferenceNo();
            LoadStock();
            lblUsername.Text = main.lblUsername.Text;
        }

        public Adjustments()
        {
        }

        public void ReferenceNo()
        {
            Random rnd = new Random();
            lblRefNo.Text = rnd.Next().ToString();
        }

        public void LoadStock()
        {
            int i = 0;
            dgvAdjustment.Rows.Clear();
            cm = new SqlCommand("SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty FROM tbProduct AS p INNER JOIN tbBrand AS b ON b.id = p.bid INNER JOIN tbCategory AS c on c.id = p.cid WHERE CONCAT(p.pdesc, b.brand, c.category) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvAdjustment.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void DgvAdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAdjustment.Columns[e.ColumnIndex].Name;
            if (colName== "Select")
            {
                lblProductCode.Text = dgvAdjustment.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblDescription.Text = dgvAdjustment.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dgvAdjustment.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + dgvAdjustment.Rows[e.RowIndex].Cells[5].Value.ToString();
                _qty = int.Parse(dgvAdjustment.Rows[e.RowIndex].Cells[7].Value.ToString());
                btnSave.Enabled = true;
            }
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
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";

                txtSearch.ForeColor = Color.White;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStock();
        }

        public void Clear()
        {
            lblDescription.Text = "";
            lblProductCode.Text = "";
            txtQty.Clear();
            txtRemarks.Clear();
            cbAction.Text = "";
            ReferenceNo();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbAction.Text) || string.IsNullOrEmpty(txtQty.Text) || string.IsNullOrEmpty(txtRemarks.Text))
                {
                    MessageBox.Show("Please provide values for action, quantity, and remarks.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int adjustmentQty = int.Parse(txtQty.Text);

                // Update Stock
                if (cbAction.Text == "Remove From Inventory")
                {
                    // Check if adjustment quantity is greater than the stock on hand
                    if (adjustmentQty > _qty)
                    {
                        MessageBox.Show("Stock on hand quantity should be greater than adjustment quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Execute the query without using parameterized queries
                    dbcon.ExecuteQuery("UPDATE tbProduct SET qty = (qty - " + adjustmentQty + ") WHERE pcode LIKE '" + lblProductCode.Text + "'");
                }
                else if (cbAction.Text == "Add To Inventory")
                {
                    // Execute the query without using parameterized queries
                    dbcon.ExecuteQuery("UPDATE tbProduct SET qty = (qty + " + adjustmentQty + ") WHERE pcode LIKE '" + lblProductCode.Text + "'");
                }

                // Insert Adjustment Record
                // Execute the query without using parameterized queries
                dbcon.ExecuteQuery("INSERT INTO tbAdjustment(referenceno, pcode, qty, action, remarks, sdate, [user]) VALUES " +
                                   "('" + lblRefNo.Text + "', '" + lblProductCode.Text + "', " + adjustmentQty + ", '" + cbAction.Text + "', '" + txtRemarks.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + lblUsername.Text + "')");

                MessageBox.Show("Stock has been successfully adjusted.", "Process completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStock();
                Clear();
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
