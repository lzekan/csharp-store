namespace testProject
{
    partial class frmPayment
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
            this.components = new System.ComponentModel.Container();
            this.pbCoupon = new System.Windows.Forms.ProgressBar();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.timerCoupon = new System.Windows.Forms.Timer(this.components);
            this.lblCouponState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbCoupon
            // 
            this.pbCoupon.Location = new System.Drawing.Point(577, 201);
            this.pbCoupon.Name = "pbCoupon";
            this.pbCoupon.Size = new System.Drawing.Size(231, 29);
            this.pbCoupon.TabIndex = 0;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(534, 94);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(125, 27);
            this.txtDiscount.TabIndex = 1;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(726, 94);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(114, 29);
            this.btnDiscount.TabIndex = 2;
            this.btnDiscount.Text = "Use Coupon";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(744, 388);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(125, 27);
            this.txtPrice.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(626, 391);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(82, 20);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Total price:";
            // 
            // timerCoupon
            // 
            this.timerCoupon.Interval = 1000;
            this.timerCoupon.Tick += new System.EventHandler(this.timerCoupon_Tick);
            // 
            // lblCouponState
            // 
            this.lblCouponState.AutoSize = true;
            this.lblCouponState.Location = new System.Drawing.Point(626, 243);
            this.lblCouponState.Name = "lblCouponState";
            this.lblCouponState.Size = new System.Drawing.Size(162, 20);
            this.lblCouponState.TabIndex = 5;
            this.lblCouponState.Text = "No coupon is activated";
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 734);
            this.Controls.Add(this.lblCouponState);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.pbCoupon);
            this.Name = "frmPayment";
            this.Text = "frmPayment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayment_FormClosed);
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbCoupon;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Timer timerCoupon;
        private System.Windows.Forms.Label lblCouponState;
    }
}