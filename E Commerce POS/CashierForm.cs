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
    public partial class CashierForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string SaveTitle = "Point of Sales";


        string Id;
        string price;
        public CashierForm()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            GetTransactionNO();
            DateLabel.Text = DateTime.Now.ToString("D");
            LoadCart();
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                Application.Exit(); 
            }
           
        }
        public void Slide(Button button)
        {
            SlidePanel.BackColor = Color.White;
            SlidePanel.Height = button.Height;
            SlidePanel.Top = button.Top;
        }
        #region Button
        private void NewTransactionButton_Click(object sender, EventArgs e)
        {
            Slide(NewTransactionButton);
            GetTransactionNO();
        }

        private void SearchProductButton_Click(object sender, EventArgs e)
        {
            Slide(SearchProductButton);
            ProductSearch Search = new ProductSearch(this);
            Search.LoadProduct(); 
            Search.ShowDialog();
        }

        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            Slide(AddDiscountButton);
            DiscountForm discountform = new DiscountForm(this);
            discountform.IDLabel.Text = Id;
            discountform.TotalPriceTextBox.Text = price;
            discountform.ShowDialog();
            discountform.DIscountPercentTextBox.Focus();
        }

        private void SettlePaymentButton_Click(object sender, EventArgs e)
        {
            Slide(SettlePaymentButton);
            SettlePaymentForm settlePaymentForm = new SettlePaymentForm(this);
            settlePaymentForm.SaleTotalTextBox.Text = DisplayTotalLabel.Text;
            settlePaymentForm.ShowDialog(); 

        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            Slide(ClearCartButton);
            if (MessageBox.Show("Remove all items from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                cmd = new SqlCommand("Delete from tbCarts WHERE transactionnumber LIKE '" + TransactionNumberLabel.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close(); 
                LoadCart();
                MessageBox.Show("All items has been sucessfully removed", " Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
               


            }
        }

        private void DailySalesButton_Click(object sender, EventArgs e)
        {
            Slide(DailySalesButton);
            DailySales dailysales = new DailySales();
            dailysales.SoldUser = NameLabel.Text;
            dailysales.ShowDialog();

        }

        private void ChangePaswordButton_Click(object sender, EventArgs e)
        {
            Slide(ChangePaswordButton);
            ChangePasswordForm change = new ChangePasswordForm(this);
            change.ShowDialog();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Slide(LogoutButton);
             if(DGVCashier.Rows.Count > 0)
            {
                MessageBox.Show("Unable to Logout." +" Please cancel the transaction ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) ;
                return;
            }

            if (MessageBox.Show("Logout Application ? ", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            } 
        }
        #endregion Button
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = DateTime.Now.ToString("h:mm tt");
        }
        
        public void GetTransactionNO()
        {
            try
            {
                string SaveDate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string TransactionNO;
                conn.Open();
                cmd = new SqlCommand("SELECT TOP 1 transactionnumber FROM tbCarts WHERE transactionnumber LIKE '" + SaveDate + "%' ORDER BY Id desc", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    TransactionNO = dr[0].ToString();
                    count = int.Parse(TransactionNO.Substring(8, 4));
                    TransactionNumberLabel.Text = SaveDate + (count + 1);
                }
                else
                {
                    TransactionNO = SaveDate + "1001";
                    TransactionNumberLabel.Text = TransactionNO;
                }
                dr.Close();
                conn.Close();

            }
            catch (Exception ex ) 
            {
                conn.Close();
                MessageBox.Show(ex.Message,SaveTitle);


            }


        }

        public void LoadCart()
        {
            
            int i = 0;
            double total= 0;
            double discount = 0;

            DGVCashier.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("SELECT Id,price,reg,disc,total FROM tbCarts WHERE transactionnumber LIKE @transactionnumber and status LIKE 'pending'" ,conn);
            cmd.Parameters.AddWithValue("@transactionnumber", TransactionNumberLabel.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())

            {
                i++;
                total += Convert.ToDouble(dr["total"].ToString());
                discount  += Convert.ToDouble(dr["disc"].ToString());
                DGVCashier.Rows.Add(i, dr["Id"].ToString(), dr["reg"].ToString(), dr["price"].ToString(), dr["disc"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
            }
            if (DGVCashier.Rows.Count == 0)
            {
                AddDiscountButton.Enabled = false;
                SettlePaymentButton.Enabled = false;
                ClearCartButton.Enabled = false;
            }
            else if (DGVCashier.Rows.Count >= 1)
            {

                AddDiscountButton.Enabled = true;
                SettlePaymentButton.Enabled =   true;
                ClearCartButton.Enabled = true;
            }
            dr.Close();
            conn.Close();
            SalesLabel.Text = total.ToString("#,##0.00");
            DIscountLabel.Text = discount.ToString("#,##0.00");
            GetCartTotal();

        }
        public  void GetCartTotal()
        {
            double discount = double.Parse(DIscountLabel.Text);
            double sales  = double.Parse(SalesLabel.Text) - discount ;
            double vat = sales * 0.12;//12% value added tax 
            double vatable = sales - vat;

            TaxLabel.Text = vat.ToString("#,##0.00");
            VatableLabel.Text = vatable.ToString("#,##0.00");
            DisplayTotalLabel.Text = sales.ToString("#,##0.00");

        }

        private void DGVCashier_SelectionChanged(object sender, EventArgs e)
        {
            int i = DGVCashier.CurrentRow.Index;
            Id = DGVCashier[1, i].Value.ToString();
            price = DGVCashier[5, i].Value.ToString();


        }

        private void DGVCashier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = DGVCashier.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tbCarts WHERE transactionnumber LIKE '" + TransactionNumberLabel.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadCart();
                    MessageBox.Show("Car has been sucessfully deleted from Cart.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

      
    }
}
