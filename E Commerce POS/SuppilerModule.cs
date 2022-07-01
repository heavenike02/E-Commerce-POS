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
    public partial class SupplierModule : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string savetitle = "Point of Sales ";
        Supplier supplier;

        public SupplierModule(Supplier sp)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            supplier = sp;  
        }

    

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Supplier?", "Save Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("INSERT INTO tbsupplier (supplier,address,contactperson,email,phonenum,fax)VALUES(@supplier,@address,@contactperson,@email,@phonenum,@fax)", conn);

                    cmd.Parameters.AddWithValue("@supplier",SuppilerNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@address",AddressTextBox.Text);
                    cmd.Parameters.AddWithValue("@contactperson",ContactPersonTextBox.Text);
                    cmd.Parameters.AddWithValue("@email",EmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@phonenum", PhoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@fax",FaxTextBox.Text);
                    

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Supplier Details has been saved sucessfully ", savetitle);
                    Clear();
                    supplier.LoadSupply();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void Clear()
        {

            
            SuppilerNameTextbox.Clear();
            SuppilerNameTextbox.Focus();
            AddressTextBox.Clear();
            ContactPersonTextBox.Clear();
            EmailTextBox.Clear();
            PhoneTextBox.Clear();   
            FaxTextBox.Clear();
            SaveButton.Enabled = true;
            UpdateButton.Enabled = false;
        }
        private void ExitPictureBox_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();    
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (MessageBox.Show("Are you sure you want to update this record?", "Update ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {    
                    cmd = new SqlCommand("UPDATE tbsupplier SET supplier=@supplier,address=@address,contactperson=@contactperson,email=@email,phonenum=@phonenum,fax=@fax WHERE Id LIKE @Id ", conn);
                    cmd.Parameters.AddWithValue("@Id", IDLabel.Text);
                    cmd.Parameters.AddWithValue("@supplier", SuppilerNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@address", AddressTextBox.Text);
                    cmd.Parameters.AddWithValue("@contactperson", ContactPersonTextBox.Text);
                    cmd.Parameters.AddWithValue("@email", EmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@phonenum", PhoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@fax", FaxTextBox.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close(); 
                    Clear();
                    MessageBox.Show("Product has been Updated sucessfully ", "Update Complete", MessageBoxButtons.OK,MessageBoxIcon.Information);


                    
                    this.Dispose();// to close form after update 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Warning" );
            }

        }
    }
}
