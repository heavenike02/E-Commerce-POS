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
    public partial class DailySales : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        double total = 0;   
        public DailySales()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            LoadCashier();
            
        }

       
        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCashier()
        {
            CashierComboBox.Items.Clear();
            CashierComboBox.Items.Add("All Cashier");
           

            conn.Open();
            cmd = new SqlCommand("SELECT * FROM tbUsersettings WHERE role LIKE 'Sales Personel'", conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                CashierComboBox.Items.Add(dr["name"].ToString());
                 
            }
                dr.Close(); 
                conn.Close();  
        }
        public void LoadSoldProduct()
        {
            if (CashierComboBox.SelectedIndex  > - 1)
            {
                DGVSold.Rows.Clear();
                int i = 0;

               
                try {
                    conn.Open(); 

                    if (CashierComboBox.Text == "All Cashier")
                    {
                        cmd = new SqlCommand("SELECT Id,price,reg,disc,transactionnumber,deposit,total,saledate,cashier FROM tbCarts WHERE  status LIKE 'Sold' and saledate BETWEEN  CONVERT(datetime, '" + DateFromPicker.Value + "', 103)AND CONVERT(datetime,  '" + DateToPicker.Value + "', 103) ", conn);

                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT Id,price,reg,disc,transactionnumber,deposit,total,saledate,cashier FROM tbCarts WHERE status LIKE 'Sold' and saledate BETWEEN  CONVERT(datetime, '" + DateFromPicker.Value + "', 103)AND CONVERT(datetime,  '" + DateToPicker.Value + "', 103)  and  cashier like '" + CashierComboBox.Text + "'", conn);
                    }
                    dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        i++;


                        total += double.Parse(dr["total"].ToString());
                        DGVSold.Rows.Add(i, dr["Id"].ToString(), dr["transactionnumber"].ToString(), dr["reg"].ToString(), dr["price"].ToString(), dr["disc"].ToString(), dr["deposit"].ToString(), dr["total"].ToString(), dr["cashier"].ToString(), dr["saledate"].ToString());
                    }

                    dr.Close();
                    conn.Close();
                    TotalLabel.Text = total.ToString("#,##0.00 ");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } 
            else
            {
                MessageBox.Show("Please select a cashier.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CashierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            LoadSoldProduct();

        }

        private void DateToPicker_ValueChanged(object sender, EventArgs e)
        {
            LoadSoldProduct();

        }

        private void DateFromPicker_ValueChanged(object sender, EventArgs e)
        {
            LoadSoldProduct();

        }
    }
}
