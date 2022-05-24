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
    public partial class MainForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public MainForm()
        {
            InitializeComponent();
           StartBlankDesign();
            conn = new SqlConnection();
        }
        #region SidebarPanel
        //method to make sub panels not visible
        private void StartBlankDesign()
        {
            FIlesSubPanel.Visible = false;
            ProductSubPanel.Visible = false;
            SettingsSubPanel.Visible = false;
            StockSubPanel.Visible = false;

        }

        private void HideSubPanel() 
        { 
            if (FIlesSubPanel.Visible == true)
                FIlesSubPanel.Visible = false;

            if (ProductSubPanel.Visible == true)
                ProductSubPanel.Visible = false; 

            if (SettingsSubPanel.Visible == true)
                SettingsSubPanel.Visible = false; 

            if (StockSubPanel.Visible == true)
                StockSubPanel.Visible = false;
        }

        private void ShowSubMenu(Panel Submenu)
        {
            if (Submenu.Visible == false) 
            { 

                HideSubPanel();
                Submenu.Visible = true;
            }
            else
                Submenu.Visible = false;
            
        }
        #endregion SidebarPanel

        private void MainBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StockSubPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductListButton_Click(object sender, EventArgs e)
        {

        }
    }
}
