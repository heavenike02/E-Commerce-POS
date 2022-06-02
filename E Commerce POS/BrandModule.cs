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
    public partial class BrandModule : Form
    {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DBConnect dbcon = new DBConnect();
            BrandForm BrandForm;
       
        public BrandModule(BrandForm br)
        {
            conn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            BrandForm = br;
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this brand", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    
                    
                    cmd = new SqlCommand("INSERT INTO tbBrand(brand)VALUES(@brand)", conn);
                    cmd.Parameters.AddWithValue("@brand", BrandNameTextbox.Text);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record has been sucessful saved.", "POS");
                    Clear();
                    BrandForm.LoadBrand();
                } 

            }
            catch(Exception ex )
            {
              MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        { 
            BrandNameTextbox.Clear();
            UpdateButton.Enabled = false;
            SaveButton.Enabled = true;
            BrandNameTextbox.Focus();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update  this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                cmd = new SqlCommand("UPDATE tbBrand SET brand = @brand WHERE id LIKE'" + IDLabel.Text + "'", conn);
                cmd.Parameters.AddWithValue("@brand", BrandNameTextbox.Text);
                cmd.ExecuteNonQuery();
                conn.Close ();
                MessageBox.Show("Brand has been sucessfully updated", "POS");
                Clear();
                this.Dispose();// to close form after update 






















































































































































































































































































































































































































































































            }
        }
    }


}
