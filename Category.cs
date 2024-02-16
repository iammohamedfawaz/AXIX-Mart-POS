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
    public partial class Category : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Category()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadCategory();
        }

        //Data retrieve from tbCategory to dgvCategory on Category form
        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tbCategory ORDER BY category", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr["id"].ToString(), dr["category"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CategoryModule module = new CategoryModule(this);
            module.ShowDialog();
        }

        private void DgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //For update and delete category by cell click from tbCategory
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "DELETE")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE From tbCategory WHERE id LIKE '" + dgvCategory[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Category has been successfully deleted.", "Point of Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (colName == "EDIT")
            {
                CategoryModule categoryModule = new CategoryModule(this);
                categoryModule.lblId.Text = dgvCategory[1, e.RowIndex].Value.ToString();
                categoryModule.txtCategory.Text = dgvCategory[2, e.RowIndex].Value.ToString();
                categoryModule.btnSave.Enabled = false;
                categoryModule.btnUpdate.Enabled = true;
                categoryModule.ShowDialog();
            }
            LoadCategory();
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
            LoadCategory();
        }
    }
}
