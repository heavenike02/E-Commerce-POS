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
    public partial class CancelOrderForm : Form
    {
        DailySales dailysales;

        public CancelOrderForm(DailySales sale)
        {
            InitializeComponent();

            dailysales = sale;
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (InventoryComboBox.Text != string.Empty && ReasonTextBox.Text != string.Empty)
                {
                    VoidForm @voidform = new VoidForm(this);
                    @voidform.ShowDialog();

                }
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
         
        public void ReloadSoldList()
        {
            dailysales.LoadSoldProduct();

        }




    }
}
