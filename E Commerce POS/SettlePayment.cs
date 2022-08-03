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
    public partial class SettlePaymentForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        CashierForm cashierform;
        public SettlePaymentForm(CashierForm cash)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            cashierform = cash;
        }

        private void SettlePaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {

            try{
            
                for(int i = 0; i < cashierform.DGVCashier.Rows.Count; i++)
                { 
                    
                   /* cmd = new SqlCommand("UPDATE tbProduc SET qty = 0  WHERE reg LIKE '" + cashierform.DGVCashier.Rows[i].Cells[2].Value.ToString() + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    cmd = new SqlCommand("UPDATE tbCart Set status = 'Sold' WHERE id = ' " + cashierform.DGVCashier.Rows[i].Cells[1].Value.ToString() + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                   */                   
                    double Deposit = double.Parse(DepositTextBox.Text)/ cashierform.DGVCashier.Rows.Count;
                  
                    conn.Open();
                    cmd = new SqlCommand("UPDATE tbCarts Set deposit =  "+ Deposit + "WHERE id = ' " + cashierform.DGVCashier.Rows[i].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                

                MessageBox.Show("Deposit sucessfully saved!", " Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cashierform.GetTransactionNO();
                cashierform.LoadCart();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += OneButton.Text;
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += TwoButton.Text;
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += ThreeButton.Text;
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += FourButton.Text;
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += FiveButton.Text;
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += SixButton.Text;
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += SevenButton.Text;
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += EightButton.Text;
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += NineButton.Text;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Clear();
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            DepositTextBox.Text += ZeroButton.Text;
        }

        private void CashTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Sale = double.Parse(SaleTotalTextBox.Text);
                double Deposit = double.Parse(DepositTextBox.Text);
                double Remaining  = Sale - Deposit;
                ChangeTextBox.Text = Remaining.ToString("#,##0.00");
            }
            catch (Exception)
            {

                ChangeTextBox.Text = "0.00";
            }
        }
    }
}
