
namespace testProject
{
    partial class frmSQLTest
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
            this.dgridOrders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgridOrders
            // 
            this.dgridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridOrders.Location = new System.Drawing.Point(27, 37);
            this.dgridOrders.Name = "dgridOrders";
            this.dgridOrders.RowTemplate.Height = 25;
            this.dgridOrders.Size = new System.Drawing.Size(889, 539);
            this.dgridOrders.TabIndex = 0;
            // 
            // frmSQLTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 588);
            this.Controls.Add(this.dgridOrders);
            this.Name = "frmSQLTest";
            this.Text = "frmSQLTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSQLTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridOrders;
    }
}