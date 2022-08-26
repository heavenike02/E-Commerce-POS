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
        DBConnect dbcon = new DBConnect();
        public string _pass;

        public MainForm()
        {
            InitializeComponent();
            StartBlankDesign();
            conn = new SqlConnection(dbcon.myConnection());
            conn.Open();


        }
        #region SidebarPanel
        //method to make sub panels not visible
        private void StartBlankDesign()
        {
            FIlesSubPanel.Visible = false;
            ProductSubPanel.Visible = false;
            SettingsSubPanel.Visible = false;
           

        }

        private void HideSubPanel()
        {
            if (FIlesSubPanel.Visible == true)
                FIlesSubPanel.Visible = false;

            if (ProductSubPanel.Visible == true)
                ProductSubPanel.Visible = false;

            if (SettingsSubPanel.Visible == true)
                SettingsSubPanel.Visible = false;

          
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

        private Form ActiveForm = null;
        // to open children form cnnected to the main application 
        public void OpenChildFord(Form ChildForm)
            
        {
            if (ActiveForm != null)
                ActiveForm.Close();
                ActiveForm = ChildForm;
                ChildForm.TopLevel = false;
                ChildForm.FormBorderStyle = FormBorderStyle.None;
                ChildForm.Dock = DockStyle.Fill;
                TitleLabel.Text = ChildForm.Text;
            MainBody.Controls.Add(ChildForm);
            MainBody.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();   
        }

        #region Button
        private void DashBoardButton_Click(object sender, EventArgs e)
        {
            HideSubPanel();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            ShowSubMenu(ProductSubPanel);
        }

        private void ProductListButton_Click(object sender, EventArgs e)
        {
            OpenChildFord(new Product());
            HideSubPanel();
        }

        private void BrandButton_Click(object sender, EventArgs e)
        {
            OpenChildFord(new BrandForm()); 
            HideSubPanel();
        }

        private void CatergoryButton_Click(object sender, EventArgs e)
        {

            OpenChildFord(new CategoryForm()); 
            HideSubPanel();
        }

        

        private void StockEntryButton_Click(object sender, EventArgs e)
        {
            HideSubPanel();
        }

        private void StockAdjustmentButton_Click(object sender, EventArgs e)
        {
            HideSubPanel();
        }

        private void FilesButton_Click(object sender, EventArgs e)
        {
            ShowSubMenu(FIlesSubPanel);
        }

        private void SalesHistoryButton_Click(object sender, EventArgs e)
        {
            HideSubPanel();
        }

        private void PosRecord_Click(object sender, EventArgs e)
        {
            HideSubPanel();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ShowSubMenu(SettingsSubPanel);
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            OpenChildFord(new UserAccount(this));
            HideSubPanel();

        }

        private void StoreButton_Click(object sender, EventArgs e)
        {
            HideSubPanel();
        }

        private void SupplierButton_Click(object sender, EventArgs e)
        {
            OpenChildFord(new Supplier ());
            HideSubPanel();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            HideSubPanel();
            if (MessageBox.Show("Logout Application ? ", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }


        #endregion Button

        
    }
}
