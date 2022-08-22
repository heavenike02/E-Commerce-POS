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
    public partial class VoidForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        CancelOrderForm cancelOrderForm;

        public VoidForm(CancelOrderForm cancel)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            cancelOrderForm = cancel;
        }

        private void VoidButton_Click(object sender, EventArgs e)
        {
            try
            {
                string user;
                conn.Open();
                cmd = new SqlCommand("Select * From tbUsersettings where username = @username and password = @password", conn);
                cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                cmd.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    user = dr["username"].ToString();
                    dr.Close();
                    conn.Close();
                    SaveCancelOrder(user);
                    if(cancelOrderForm.InventoryComboBox.Text == "Yes")
                    {
                        cmd = new SqlCommand("UPDATE tbProduc SET qty = 1  WHERE reg LIKE '" + cancelOrderForm.RegTextBox.Text + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        
                    }

                    cmd = new SqlCommand("UPDATE tbCarts Set status = 'void' WHERE reg LIKE '" + cancelOrderForm.RegTextBox.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Order transaction sucessfully cancelled!", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    cancelOrderForm.ReloadSoldList();
                    cancelOrderForm.Dispose();
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveCancelOrder(string user)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("Insert into tbCancelled (transactionnumber, price,disc,total, saledate, reg,deposit,voidby,cancelledby,reason,action ) values " +
                                                             "(@transactionnumber,@price,@disc,@total,@saledate,@reg,@deposit,@voidby,@cancelledby,@reason,@action)",conn);
               
                cmd.Parameters.AddWithValue("@transactionnumber", cancelOrderForm.TransactionNoTextBox.Text);
                cmd.Parameters.AddWithValue("@price", cancelOrderForm.PriceTextBox.Text);
                cmd.Parameters.AddWithValue("@disc", cancelOrderForm.DiscountTextBox.Text);
                cmd.Parameters.AddWithValue("@total", cancelOrderForm.TotalTextBox.Text);
                cmd.Parameters.AddWithValue("@saledate",DateTime.Now);
                cmd.Parameters.AddWithValue("@deposit", cancelOrderForm.DepositTextBox.Text);
                cmd.Parameters.AddWithValue("@reg", cancelOrderForm.RegTextBox.Text); 
                cmd.Parameters.AddWithValue("@voidby", user);
                cmd.Parameters.AddWithValue("@cancelledby", cancelOrderForm.CancelledByTextBox.Text);
                cmd.Parameters.AddWithValue("@reason", cancelOrderForm.ReasonTextBox.Text);
                cmd.Parameters.AddWithValue("@action", cancelOrderForm.InventoryComboBox.Text);
                cmd.ExecuteNonQuery();
                conn.Close();






            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
