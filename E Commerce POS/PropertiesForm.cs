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
    public partial class PropertiesForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string username;
        UserAccount account;
        public PropertiesForm(UserAccount acc)
        {
            conn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            account = acc;
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want change this account properties", "User Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("UPDATE tbUsersettings set name=@name, role=@role, isactive=@isactive WHERE username=@username",conn);
                    cmd.Parameters.AddWithValue("@name", NameTextbox.Text);
                    cmd.Parameters.AddWithValue("@role", RoleComboBox.Text);
                    cmd.Parameters.AddWithValue("@isactive", AccountStatusComboBox.Text);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Account propeties has been sucessfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    account.LoadUserAccounts();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                
            }
        }
    }
}
