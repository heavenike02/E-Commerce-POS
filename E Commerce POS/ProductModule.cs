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
        public ProductModule(Product pd)

        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            product = pd;
            LoadBrand();
            LoadCategory();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbProduc (bid,cid,model,reg,trim,price,fueltype,enginesize,mileage,transmission,roadtax,description)VALUES(@bid,@cid,@model,@reg,@trim,@price,@fueltype,@enginesize,@mileage,@transmission,@roadtax,@description)", conn);
                    cmd.Parameters.AddWithValue("@bid", BrandComboBox.Text);
                    cmd.Parameters.AddWithValue("@cid", CategoryComboBox.Text);

                    cmd.Parameters.AddWithValue("@model", ModelTextBox.Text);
                    cmd.Parameters.AddWithValue("@reg", RegTextBox.Text);


                    cmd.Parameters.AddWithValue("@trim", TrimTextBox.Text);
                    cmd.Parameters.AddWithValue("@price", PriceUpDown.Value);
                    cmd.Parameters.AddWithValue("@fueltype", FuelTypeTextBox.Text);
                    cmd.Parameters.AddWithValue("@enginesize", EngineSIzeUpDown.Value);
                    cmd.Parameters.AddWithValue("@mileage", MileageUpDown.Value);


                    cmd.Parameters.AddWithValue("@transmission", TransmissionTextBox.Text);
                    cmd.Parameters.AddWithValue("@roadtax", RoadTaxUpDown.Value);

                    cmd.Parameters.AddWithValue("@description", DescriptionTextBox.Text);




                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product has been saved sucessfully ", savetitle);
                    Clear();
                    product.LoadProduct();
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
            TransmissionTextBox.Clear();

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
            CategoryComboBox.ValueMember = "Id";
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
            try
            {
                if (MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbProduc SET bid=@bid,cid=@cid,model=@model,reg=@reg,trim=@trim,price=@price,fueltype=@fueltype,enginesize=@enginesize,mileage=@mileage,transmission=@transmission,roadtax=@roadtax,description=@description WHERE reg LIKE @reg ",conn);
                    cmd.Parameters.AddWithValue("@bid", BrandComboBox.Text);
                    cmd.Parameters.AddWithValue("@cid", CategoryComboBox.Text);

                    cmd.Parameters.AddWithValue("@model", ModelTextBox.Text);
                    cmd.Parameters.AddWithValue("@reg", RegTextBox.Text);


                    cmd.Parameters.AddWithValue("@trim", TrimTextBox.Text);
                    cmd.Parameters.AddWithValue("@price", PriceUpDown.Value);
                    cmd.Parameters.AddWithValue("@fueltype", FuelTypeTextBox.Text);
                    cmd.Parameters.AddWithValue("@enginesize", EngineSIzeUpDown.Value);
                    cmd.Parameters.AddWithValue("@mileage", MileageUpDown.Value);


                    cmd.Parameters.AddWithValue("@transmission", TransmissionTextBox.Text);
                    cmd.Parameters.AddWithValue("@roadtax", RoadTaxUpDown.Value);

                    cmd.Parameters.AddWithValue("@description", DescriptionTextBox.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();Clear();
                    MessageBox.Show("Product has been Updated sucessfully ", "Update Complete");


                    Task.Delay(1000).Wait();
                    this.Dispose();// to close form after update 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
