using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace E_Commerce_POS
{

    public partial class Supplier : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Supplier()
        {
            conn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            LoadSupply();
        }
            public void LoadSupply()

            {
            try
            {

                DGVSuppiler.Rows.Clear();
          
                cmd = new SqlCommand("SELECT * FROM tbsupplier", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
              
                    DGVSuppiler.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),dr[5].ToString(),dr[6].ToString());
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
            SupplierModule supplierModule = new SupplierModule(this);
            supplierModule.UpdateButton.Enabled = false;
            supplierModule.SaveButton.Enabled = true;
            supplierModule.ShowDialog();
            
            
        }

        private void DGVSuppiler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // for update and delete brand by cell click from tbBrand
            string colName = DGVSuppiler.Columns[e.ColumnIndex].Name;
            if (colName == "Edit1")
            {
                SupplierModule supplierModule = new SupplierModule(this);
                supplierModule.IDLabel.Text = DGVSuppiler.Rows[e.RowIndex].Cells[0].Value.ToString();
                supplierModule.SuppilerNameTextbox.Text = DGVSuppiler.Rows[e.RowIndex].Cells[1].Value.ToString();
                supplierModule.AddressTextBox.Text =  DGVSuppiler.Rows[e.RowIndex].Cells[2].Value.ToString();
                supplierModule.ContactPersonTextBox.Text = DGVSuppiler.Rows[e.RowIndex].Cells[3].Value.ToString();
                supplierModule.EmailTextBox.Text = DGVSuppiler.Rows[e.RowIndex].Cells[4].Value.ToString();
                supplierModule.PhoneTextBox.Text =  DGVSuppiler.Rows[e.RowIndex].Cells[5].Value.ToString();
                supplierModule.FaxTextBox.Text =  DGVSuppiler.Rows[e.RowIndex].Cells[6].Value.ToString();
                supplierModule.SaveButton.Enabled = false;
                supplierModule.UpdateButton.Enabled = true;
                supplierModule.ShowDialog();
            }

            if (colName == "Delete")
               
             {  
                
                
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tbsupplier WHERE supplier LIKE '" + DGVSuppiler[1, e.RowIndex].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Supplier has been sucessfully deleted.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            LoadSupply();
        }
    }



   















}
