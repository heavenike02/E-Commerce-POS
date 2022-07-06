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
    public partial class UserAccount : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        public UserAccount()
        {
            conn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
        }

       

        private void UserAccount_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTextbox.Text != ReTypePasswordTextBox.Text)
                {
                    MessageBox.Show(" Password did not Match .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to Create  this Account?", "Create Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("Insert into tbUsersettings(username,password,role,name)Values (@username,@password,@role,@name)",conn);
                    cmd.Parameters.AddWithValue("@username", UserNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@password", PasswordTextbox.Text);
                    cmd.Parameters.AddWithValue("@role", RoleComboBox.Text);
                    cmd.Parameters.AddWithValue("@name", FullNameTextBox.Text);
                    cmd.ExecuteNonQuery(); ;
                    conn.Close();
                    MessageBox.Show(" New Account has been sucessfully saved.", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message, "warning");
            }
        }

        public void Clear() 
        {
            PasswordTextbox.Clear();
            FullNameTextBox.Clear();
            RoleComboBox.Text = "";
            UserNameTextbox.Clear();
            ReTypePasswordTextBox.Clear();
        }
}
}
