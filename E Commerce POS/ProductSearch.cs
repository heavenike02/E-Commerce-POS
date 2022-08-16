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


namespace E_Commerce_POS
{
    public partial class ProductSearch : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
     
        private double price;
        private string cashier;
        private string reg;
        CashierForm cashierForm;
        public ProductSearch(CashierForm Cash)
        {
            conn = new SqlConnection(dbcon.myConnection());

            InitializeComponent();
            LoadProduct();
            cashierForm = Cash;

        }

        public void LoadProduct()
        {
            try
            {

                DGVProductSearch.Rows.Clear();
                
                cmd = new SqlCommand("SELECT * FROM tbProduc WHERE qty = 0 AND reg LIKE '%" + SearchMetroTextBox.Text + "%' OR  qty = 1 AND  bid LIKE '%" + SearchMetroTextBox.Text + "%' OR  qty = 1 AND  model LIKE '%" + SearchMetroTextBox.Text + "%' OR  qty = 1 AND cid LIKE '%" + SearchMetroTextBox.Text + "%' OR  qty = 1 AND  bid LIKE '%" + SearchMetroTextBox.Text + "%'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    DGVProductSearch.Rows.Add(dr["Id"].ToString(), dr["cid"].ToString(), dr["bid"].ToString(), dr["model"].ToString(), dr["description"].ToString(), dr["reg"].ToString(), dr["qty"].ToString(), dr["price"].ToString(), dr["fueltype"].ToString(), dr["enginesize"].ToString(), dr["mileage"].ToString(), dr["transmission"].ToString(), dr["roadtax"].ToString());
                }
                dr.Close();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


        




        private void SearchMetroTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DGVProductSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = DGVProductSearch.Columns[e.ColumnIndex].Name;
           
            if (ColName == "Select")
            {
             if (MessageBox.Show("Are you sure you want to add this car to your cart ?", "Add to Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                cmd = new SqlCommand("INSERT INTO tbCarts (transactionnumber,price,saledate,cashier,reg)VALUES(@transactionnumber,@price,@saledate,@cashier,@reg)", conn);
                price =  double.Parse(DGVProductSearch[7, e.RowIndex].Value.ToString());
                cashier = cashierForm.NameLabel.Text;
                reg = DGVProductSearch[5, e.RowIndex].Value.ToString();
                cmd.Parameters.AddWithValue("@transactionnumber", cashierForm.TransactionNumberLabel.Text);
                cmd.Parameters.AddWithValue("@price",price);
                cmd.Parameters.AddWithValue("@reg", reg);
                cmd.Parameters.AddWithValue("@saledate", DateTime.Now);
                cmd.Parameters.AddWithValue("@cashier", cashier);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cashierForm.LoadCart();
                MessageBox.Show("Car has been sucessfully inserted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             







            }
        }
    }
}
