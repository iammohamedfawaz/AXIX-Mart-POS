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
    public partial class CancelOrder : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        DailySales dailySale;
        public CancelOrder(DailySales sale)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            dailySale = sale;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbAddInventory.Text != string.Empty && numericDownCancelQty.Value > 0 && txtReasons.Text != string.Empty)
                {
                    if (int.Parse(txtQty.Text) >= numericDownCancelQty.Value)
                    {
                        Void @void = new Void(this);
                        @void.txtUsername.Focus();
;                        @void.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ReloadSoldList()
        {
            dailySale.LoadSold();
        }

        private void CbAddInventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
