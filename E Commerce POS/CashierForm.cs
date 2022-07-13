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
        public CashierForm()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
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
        }

        private void SettlePaymentButton_Click(object sender, EventArgs e)
        {
            Slide(SettlePaymentButton);
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            Slide(ClearCartButton);
        }

        private void DailySalesButton_Click(object sender, EventArgs e)
        {
            Slide(DailySalesButton);
        }

        private void ChangePaswordButton_Click(object sender, EventArgs e)
        {
            Slide(ChangePaswordButton);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Slide(LogoutButton);
        }
        #endregion Button
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = DateTime.Now.ToString("h:mm tt");
        }
        
        public void GetTransactionNO()
        {
            //Random generator = new Random();
            //string Randomnumber = generator.Next(1, 10000).ToString("D4");
            string SaveDate = DateTime.Now.ToString("yyyyMMdd");
            string TransactionNO = SaveDate + "1001";
            TransactionNumberLabel.Text = TransactionNO;
        }

        public void LoadCart()
        {
            int i = 0;
            double total= 0;
            double discount = 0;

            DGVCashier.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("SELECT Id,price,reg,disc,total FROM tbCart WHERE transactionnumber LIKE @transactionnumber and status LIKE 'pending'" ,conn);
            cmd.Parameters.AddWithValue("@transactionnumber", TransactionNumberLabel.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())

            {
                i++;
                total += Convert.ToDouble(dr["total"].ToString());
                discount  += Convert.ToDouble(dr["disc"].ToString());
                DGVCashier.Rows.Add(i, dr["Id"].ToString(), dr["price"].ToString(), dr["reg"].ToString(), dr["disc"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
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



    }
}
