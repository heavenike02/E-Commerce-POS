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
    public partial class BrandForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr ;    
        public BrandForm()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            LoadBrand();
        }
        
        // Data from tbBrand to dgbBrad on brand 

        public void LoadBrand()
        {
            int i = 0;
            DGVBrand.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM tbBrand ORDER BY brand",conn);
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                i++;
                DGVBrand.Rows.Add(i, dr["id"].ToString(), dr["brand"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            BrandModule moduleForm = new BrandModule(this);
            moduleForm.ShowDialog();
        }

        private void DGVBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { // for update and delete brand by cell click from tbBrand
            string colName = DGVBrand.Columns[e.ColumnIndex].Name;
            if ( colName == "Edit")
            {
                if (MessageBox.Show("Are you sure you want to delEte this record?","Delete Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tbBrand WHERE id LIKE ' " + DGVBrand[1,e.RowIndex].Value.ToString()+ "'",conn);
                    cmd.ExecuteNonQuery();  
                    conn.Close();
                    MessageBox.Show("Brand has been sucessfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (colName == "Edit")
                {
                    BrandModule brandModule = new BrandModule(this);
                    brandModule.IDLabel.Text = DGVBrand[1,e.RowIndex].Value.ToString();
                    brandModule.BrandNameTextbox.Text = DGVBrand[2,e.RowIndex].Value.ToString();    
                    brandModule.SaveButton.Enabled = false;
                    brandModule.UpdateButton.Enabled = true;

                    brandModule.ShowDialog();
                }
                LoadBrand();
            }

        }
    }
}
