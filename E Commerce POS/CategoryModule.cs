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
    public partial class CategoryModule : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        CategoryForm CategoryForm;
        public CategoryModule(CategoryForm ct )
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            CategoryForm = ct;


        }

        public void clear()
        {
            CategoryNameTextbox.Clear();
            CategoryNameTextbox.Focus();
            SaveButton.Enabled = true;
            UpdateButton.Enabled = false;
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Category", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();


                    cmd = new SqlCommand("INSERT INTO tbCatergory(category)VALUES(@category)", conn);
                    cmd.Parameters.AddWithValue("@category", CategoryNameTextbox.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record has been sucessful saved.", "Point Of Sale");
                    clear();
                    CategoryForm.LoadCategory();    
                }                    
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                cmd = new SqlCommand("UPDATE tbCatergory SET category = @category WHERE Id LIKE'" + IDLabel.Text + "'", conn);
                cmd.Parameters.AddWithValue("@category", CategoryNameTextbox.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Category has been sucessfully updated", "POS");
                clear();
                this.Dispose();// to close form after update 
            }
        }




        private void CancelButton_Click(object sender, EventArgs e)
        {
            clear();    
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
}
