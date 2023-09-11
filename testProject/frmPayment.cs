using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testProject
{
    public partial class frmPayment : Form
    {
        frmStore frm = Application.OpenForms.OfType<frmStore>().FirstOrDefault();

        public List<string> couponsList = new List<string>();

        double updatedTotalPrice;
        bool discountActive;
        double discountPercentage = 0.0, activeDiscountPercentage = 0.0;

        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            frm.Enabled = false;
            discountActive = false;
            updatedTotalPrice = frm.totalPrice;
            txtPrice.Text = updatedTotalPrice.ToString();

            couponsList.Add("discount10");
            couponsList.Add("discount20");
            couponsList.Add("discount25");

        }

        private void frmPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm.Enabled = true;
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            timerCoupon.Start();

            bool discountGood = couponsList.Contains(txtDiscount.Text.ToString());
            
            if(discountGood)
            {
                discountPercentage = Convert.ToDouble(txtDiscount.Text.Split('t')[1]);
                if (!discountActive)
                {
                    discountActive = true;
                    activeDiscountPercentage = discountPercentage;
                    applyDiscount(discountPercentage);   
                }
                else if (discountActive)
                {
                    string question = "Are you sure you want to overwrite the current coupon for " + activeDiscountPercentage + "% with the " + discountPercentage + "% one";
                    DialogResult dr = MessageBox.Show(question, "Question", MessageBoxButtons.YesNo);

                    switch (dr)
                    {
                        case DialogResult.Yes:
                            applyDiscount(discountPercentage);
                            break;
                        case DialogResult.No:
                            break;
                    }
                }

                lblCouponState.Text = "Coupon verified.";
            }
            else
            {
                MessageBox.Show("Coupon not available.");
                txtDiscount.Text = "";
                lblCouponState.Text = "No coupon activated.";
            }
        }

        private void timerCoupon_Tick(object sender, EventArgs e)
        {
            pbCoupon.Increment(50);
            lblCouponState.Text = "Coupon is being verified...";
        }

        public void applyDiscount(double discountPercentage)
        {
            updatedTotalPrice = frm.totalPrice * (1 - discountPercentage / 100);
            MessageBox.Show("Coupon for " + discountPercentage + "% activated.");
            txtPrice.Text = updatedTotalPrice.ToString();
        }
    }
}
