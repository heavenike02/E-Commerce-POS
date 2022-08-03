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
    public partial class DiscountForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        CashierForm cashierform;
        string SaveTitle = "Point Of Sales ";
        public DiscountForm(CashierForm cash)
        {
            conn = new SqlConnection(dbcon.myConnection());

            InitializeComponent();
            cashierform = cash;
            DIscountPercentTextBox.Focus();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DIscountPercentTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double disc = double.Parse(TotalPriceTextBox.Text) * (double.Parse(DIscountPercentTextBox.Text)/100);
                DiscountAmountTextBox.Text = disc.ToString("#,##0.00");

            }
            catch (Exception)
            {
                DiscountAmountTextBox.Text = "0.00";
             
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Add discount? Click Yes to Confirm ", SaveTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("UPDATE tbCarts SET discpercent = @discpercent WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@discpercent", double.Parse(DIscountPercentTextBox.Text));
                    cmd.Parameters.AddWithValue("@Id", int.Parse(IDLabel.Text));
                    cmd.ExecuteNonQuery();
                    cashierform.LoadCart();
                    this.Dispose();

                }
            }
            catch (Exception ex )
            {

                conn.Close();
                MessageBox.Show(ex.Message, SaveTitle);

            }
        }
    }
}
