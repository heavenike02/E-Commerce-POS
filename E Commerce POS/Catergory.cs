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
    public partial class CategoryForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        public CategoryForm()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            LoadCategory();

        }
        // data retreived from tbCategory to dgvcategory
        public void LoadCategory()
        {
            int i = 0;
            DGVCatergory.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM tbCatergory ORDER BY category", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                DGVCatergory.Rows.Add(i, dr["Id"].ToString(), dr["category"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            CategoryModule moduleForm = new CategoryModule(this);
            moduleForm.UpdateButton.Enabled = false;
            moduleForm.ShowDialog();
            moduleForm.SaveButton.Enabled  = true;
            

        }

        private void DGVCatergory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // for update and delete brand by cell click from tbcatergory
            string colName = DGVCatergory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit1")
            {
                
                CategoryModule module = new CategoryModule(this);
                module.IDLabel.Text = DGVCatergory[1, e.RowIndex].Value.ToString();
                module.CategoryNameTextbox.Text = DGVCatergory[2, e.RowIndex].Value.ToString();
                module.SaveButton.Enabled = false;
                module.UpdateButton.Enabled = true;
                module.ShowDialog();
            }

            if (colName == "Delete")
            {

                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tbCatergory WHERE Id LIKE '" + DGVCatergory[1, e.RowIndex].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Category has been sucessfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            LoadCategory();
        }
    }
}
