namespace My_POS_AXIX_MART
{
    partial class CancelOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.numericDownCancelQty = new System.Windows.Forms.NumericUpDown();
            this.cbAddInventory = new System.Windows.Forms.ComboBox();
            this.txtReasons = new System.Windows.Forms.TextBox();
            this.txtCancelledBy = new System.Windows.Forms.TextBox();
            this.txtVoidBy = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTransNo = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPcode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDownCancelQty)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(93)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 40);
            this.panel1.TabIndex = 46;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(93)))), ((int)(((byte)(252)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(897, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(48, 35);
            this.btnMinimize.TabIndex = 10;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(93)))), ((int)(((byte)(252)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(945, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 35);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cancel Order Details";
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(93)))), ((int)(((byte)(252)))));
            this.btnCancelOrder.FlatAppearance.BorderSize = 0;
            this.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOrder.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(779, 600);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(158, 45);
            this.btnCancelOrder.TabIndex = 109;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.BtnCancelOrder_Click);
            // 
            // numericDownCancelQty
            // 
            this.numericDownCancelQty.Location = new System.Drawing.Point(689, 432);
            this.numericDownCancelQty.Name = "numericDownCancelQty";
            this.numericDownCancelQty.Size = new System.Drawing.Size(245, 32);
            this.numericDownCancelQty.TabIndex = 108;
            // 
            // cbAddInventory
            // 
            this.cbAddInventory.FormattingEnabled = true;
            this.cbAddInventory.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbAddInventory.Location = new System.Drawing.Point(219, 530);
            this.cbAddInventory.Name = "cbAddInventory";
            this.cbAddInventory.Size = new System.Drawing.Size(245, 31);
            this.cbAddInventory.TabIndex = 107;
            this.cbAddInventory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbAddInventory_KeyPress);
            // 
            // txtReasons
            // 
            this.txtReasons.Location = new System.Drawing.Point(689, 481);
            this.txtReasons.Multiline = true;
            this.txtReasons.Name = "txtReasons";
            this.txtReasons.Size = new System.Drawing.Size(245, 92);
            this.txtReasons.TabIndex = 106;
            // 
            // txtCancelledBy
            // 
            this.txtCancelledBy.Location = new System.Drawing.Point(219, 481);
            this.txtCancelledBy.Name = "txtCancelledBy";
            this.txtCancelledBy.Size = new System.Drawing.Size(245, 32);
            this.txtCancelledBy.TabIndex = 105;
            // 
            // txtVoidBy
            // 
            this.txtVoidBy.Location = new System.Drawing.Point(219, 432);
            this.txtVoidBy.Name = "txtVoidBy";
            this.txtVoidBy.Size = new System.Drawing.Size(245, 32);
            this.txtVoidBy.TabIndex = 104;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(689, 278);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(245, 32);
            this.txtTotal.TabIndex = 103;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(818, 229);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(116, 32);
            this.txtDiscount.TabIndex = 102;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(689, 229);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(116, 32);
            this.txtQty.TabIndex = 101;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(689, 180);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(245, 32);
            this.txtPrice.TabIndex = 100;
            // 
            // txtTransNo
            // 
            this.txtTransNo.Location = new System.Drawing.Point(689, 131);
            this.txtTransNo.Name = "txtTransNo";
            this.txtTransNo.Size = new System.Drawing.Size(245, 32);
            this.txtTransNo.TabIndex = 99;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(219, 131);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(245, 32);
            this.txtId.TabIndex = 98;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(219, 229);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(245, 92);
            this.txtDescription.TabIndex = 97;
            // 
            // txtPcode
            // 
            this.txtPcode.Location = new System.Drawing.Point(219, 180);
            this.txtPcode.Name = "txtPcode";
            this.txtPcode.Size = new System.Drawing.Size(245, 32);
            this.txtPcode.TabIndex = 96;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(524, 484);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 23);
            this.label15.TabIndex = 95;
            this.label15.Text = "Reason(S):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(524, 435);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 23);
            this.label14.TabIndex = 94;
            this.label14.Text = "Cancel Qty:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 533);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 23);
            this.label13.TabIndex = 93;
            this.label13.Text = "Add Inventory:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(59, 484);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 23);
            this.label12.TabIndex = 92;
            this.label12.Text = "Cancelled By:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 435);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 23);
            this.label11.TabIndex = 91;
            this.label11.Text = "Void By:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(524, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 23);
            this.label10.TabIndex = 90;
            this.label10.Text = "Total:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(524, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 23);
            this.label9.TabIndex = 89;
            this.label9.Text = "Qty/Discount:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(524, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 23);
            this.label8.TabIndex = 88;
            this.label8.Text = "Price:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(524, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 23);
            this.label7.TabIndex = 87;
            this.label7.Text = "Transaction No:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 23);
            this.label6.TabIndex = 86;
            this.label6.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 23);
            this.label5.TabIndex = 85;
            this.label5.Text = "Product Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 23);
            this.label4.TabIndex = 84;
            this.label4.Text = "Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 23);
            this.label3.TabIndex = 83;
            this.label3.Text = "CANCEL ITEM(S)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 82;
            this.label2.Text = "SOLD ITEM";
            // 
            // CancelOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(993, 665);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.numericDownCancelQty);
            this.Controls.Add(this.cbAddInventory);
            this.Controls.Add(this.txtReasons);
            this.Controls.Add(this.txtCancelledBy);
            this.Controls.Add(this.txtVoidBy);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtTransNo);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPcode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CancelOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CANCEL ORDER";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDownCancelQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.NumericUpDown numericDownCancelQty;
        public System.Windows.Forms.ComboBox cbAddInventory;
        public System.Windows.Forms.TextBox txtReasons;
        public System.Windows.Forms.TextBox txtCancelledBy;
        public System.Windows.Forms.TextBox txtVoidBy;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.TextBox txtDiscount;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.TextBox txtTransNo;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtPcode;
    }
}