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
    public partial class ProductModule : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string savetitle = "Point of Sales ";
        Product product;
        public ProductModule()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            
            LoadBrand();
            LoadCategory();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?","Save Product" ,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbProduct (bid,cid,model,reg,trim,price,fueltype,enginesize,mileage,roadtax,description)VALUES(@bid,@Cid,@model,@reg,@trim,@price,@fueltype,@enginesize,@mileage,@roadtax,@description)", conn);
                    cmd.Parameters.AddWithValue("@bid", BrandComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@cid", CategoryComboBox.SelectedValue);

                    cmd.Parameters.AddWithValue("@model", ModelTextBox.Text);
                    cmd.Parameters.AddWithValue("@reg", RegTextBox.Text);
                    cmd.Parameters.AddWithValue("@trim", TrimTextBox.Text);
                    
                    cmd.Parameters.AddWithValue("@fueltype", FuelTypeTextBox.Text);
                    cmd.Parameters.AddWithValue("@description", DescriptionTextBox.Text);
                    
                    cmd.Parameters.AddWithValue("@roadtax", RoadTaxUpDown.Value);
                    cmd.Parameters.AddWithValue("@price", PriceUpDown.Value);
                    cmd.Parameters.AddWithValue("@enginesize", EngineSIzeUpDown.Value);
                    cmd.Parameters.AddWithValue("@mileage", MileageUpDown.Value   );

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product has been saved sucessfully ",savetitle);
                    Clear();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        public void Clear()
        {
            BrandComboBox.SelectedIndex = 0;
            CategoryComboBox.SelectedIndex = 0;
            EngineSIzeUpDown.Value = 0.5m;
            MileageUpDown.Value = 0;
            PriceUpDown.Value = 0;
            RoadTaxUpDown.Value = 0;
            
            
            
            ModelTextBox.Clear();   
            RegTextBox.Clear(); 
            TrimTextBox.Clear();
            FuelTypeTextBox.Clear();
           
            
            DescriptionTextBox.Clear();

            CategoryComboBox.Focus();
            SaveButton.Enabled = true;
            UpdateButton.Enabled = false;
            
        }

        
        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        // to import category 
        public void LoadCategory() 
        {
            CategoryComboBox.Items.Clear();
            CategoryComboBox.DataSource = dbcon.getTable("SELECT * FROM tbCatergory");
            CategoryComboBox.DisplayMember = "category";
            CategoryComboBox.ValueMember = "Id" ;
        }
        // to import braand 
        public void LoadBrand()
        {
            BrandComboBox.Items.Clear();
            BrandComboBox.DataSource = dbcon.getTable("SELECT * FROM tbBrand");
            BrandComboBox.DisplayMember = "brand";
            BrandComboBox.ValueMember = "Id";
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {  
            Clear();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
