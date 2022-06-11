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

namespace E_Commerce_POS
{
    public partial class Product : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Product()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());

        }

        private void DGVBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
