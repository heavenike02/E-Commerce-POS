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
            LoadProduct();

        }

        public void LoadProduct()
        {
            try
            {
                
                DGVProduct.Rows.Clear();
                // cmd = new SqlCommand("SELECT  p.model,p.reg,p.trim,p.price,p.fueltype,p.enginesize,p.mileage,p.roadtax,p.description ", conn);
                cmd = new SqlCommand("SELECT * FROM tbProduc WHERE reg LIKE '%" + SearchTextBox.Text + "%' OR bid LIKE '%" + SearchTextBox.Text + "%' OR model LIKE '%" + SearchTextBox.Text + "%' OR cid LIKE '%" + SearchTextBox.Text + "%' OR bid LIKE '%" + SearchTextBox.Text + "%'",  conn);
                conn.Open();                                             // OR ID LIKE '%" + txt_SearchBar.Text + "%'
                //ORDER BY bid,cid,model,reg,trim,price,fueltype,enginesize,mileage,transmission,roadtax,description

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    DGVProduct.Rows.Add(dr["Id"].ToString(), dr["cid"].ToString(), dr["bid"].ToString(), dr["model"].ToString(), dr["reg"].ToString(), dr["trim"].ToString(), dr["price"].ToString(), dr["fueltype"].ToString(), dr["enginesize"].ToString(), dr["mileage"].ToString(), dr["transmission"].ToString(), dr["roadtax"].ToString(), dr["description"].ToString());
                }
                dr.Close();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }





        private void AddButton_Click(object sender, EventArgs e)
        {
            ProductModule productModule = new ProductModule(this);
            productModule.SaveButton.Enabled = true;
            productModule.UpdateButton.Enabled = false;
            productModule.ShowDialog();
        }

        private void DGVProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        { // for update and delete brand by cell click from tbBrand
            string colName = DGVProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit1")
            {
                ProductModule productModule = new ProductModule(this);
                productModule.BrandComboBox.Text = DGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.CategoryComboBox.Text = DGVProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.ModelTextBox.Text = DGVProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.RegTextBox.Text = DGVProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.TrimTextBox.Text = DGVProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.PriceUpDown.Text = DGVProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.FuelTypeTextBox.Text = DGVProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
                productModule.EngineSIzeUpDown.Text = DGVProduct.Rows[e.RowIndex].Cells[8].Value.ToString();
                productModule.MileageUpDown.Text = DGVProduct.Rows[e.RowIndex].Cells[9].Value.ToString();
                productModule.TransmissionTextBox.Text = DGVProduct.Rows[e.RowIndex].Cells[10].Value.ToString();
                productModule.RoadTaxUpDown.Text = DGVProduct.Rows[e.RowIndex].Cells[11].Value.ToString();
                productModule.DescriptionTextBox.Text = DGVProduct.Rows[e.RowIndex].Cells[12].Value.ToString();



                productModule.SaveButton.Enabled = false;
                productModule.UpdateButton.Enabled = true;
                productModule.ShowDialog();
            }

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tbProduc WHERE reg LIKE '" + DGVProduct[4, e.RowIndex].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Car has been sucessfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            LoadProduct();

        }

       
             private void SearchButton_Click(object sender, EventArgs e)
                {
                    
                       
     
       
                }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();

        }
    } 
}
