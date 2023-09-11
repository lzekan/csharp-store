using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace testProject
{
    public partial class frmSQLTest : Form
    {
        private readonly SqlConnection cnnMain = new SqlConnection();
       

        public frmSQLTest()
        {
            InitializeComponent();
        }

        private void frmSQLTest_Load(object sender, EventArgs e)
        {
            cnnMain.ConnectionString = "Data Source=LAPTOP-2KJJMM6S\\LUKAMSSQLSERVER; Initial Catalog=Customer; Integrated Security=true;";
               
        }
    }
}
