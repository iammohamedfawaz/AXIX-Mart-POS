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
    public partial class MainForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnect dbcon = new DBConnect();
        public string _pass;
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
            cn = new SqlConnection(dbcon.myConnection());
            cn.Open();
            MessageBox.Show("Datebase is Connected");
        }
        #region panelSlide
        private void customizeDesign()
        {
            panelSubProduct.Visible = false;
            panelSubStock.Visible = false;
            panelSubSetting.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panelSubProduct.Visible == true)
                panelSubProduct.Visible = false;
            if (panelSubStock.Visible == true)
                panelSubStock.Visible = false;
            if (panelSubSetting.Visible == true)
                panelSubSetting.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        #endregion panelSlide
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text = childForm.Text;
            panelForm.Controls.Add(childForm);
            panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        public void slide(Button button)
        {
            slideButton.BackColor = Color.White;
            slideButton.Height = button.Height;
            slideButton.Top = button.Top;


        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            slide(btnDashboard);
            openChildForm(new Dashboard());
            hideSubmenu();
        }

        private void BtnPOSCashier_Click(object sender, EventArgs e)
        {
            slide(btnPOSCashier);
            Cashier cashier = new Cashier();
            cashier.ShowDialog();
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            slide(btnProduct);
            showSubmenu(panelSubProduct);
        }

        private void BtnProductList_Click(object sender, EventArgs e)
        {
            openChildForm(new Product());
            hideSubmenu();
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new Category());
            hideSubmenu();
        }

        private void BtnBrand_Click(object sender, EventArgs e)
        {
            openChildForm(new Brand());
            hideSubmenu();
        }

        private void BtnStockIn_Click(object sender, EventArgs e)
        {
            slide(btnStockIn);
            showSubmenu(panelSubStock);
        }

        private void BtnStockEntry_Click(object sender, EventArgs e)
        {
            openChildForm(new StockIn());
            hideSubmenu();
        }

        private void BtnStockAdjustment_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new Adjustments(this));
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            slide(btnSupplier);
            openChildForm(new Supplier());
            hideSubmenu();
        }


        private void BtnSaleHistory_Click(object sender, EventArgs e)
        {
            slide(btnSupplier);
            openChildForm(new DailySales());
            hideSubmenu();
        }


        private void BtnSetting_Click(object sender, EventArgs e)
        {
            slide(btnSetting);
            showSubmenu(panelSubSetting);
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new UserAccount(this));
        }

        private void BtnStore_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            Store store = new Store();
            store.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            slide(btnLogout);
            hideSubmenu();

            if (MessageBox.Show("Logout Application?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }

     
    }

}
